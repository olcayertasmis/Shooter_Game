using System.Collections;
using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Enums;
using _GameFolder.Scripts.Manager;
using UnityEngine;
using Logger = _GameFolder.Scripts.Services.Logger;
using Random = UnityEngine.Random;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class Enemy : BaseCharacter
    {
        [Header("Enums")]
        [SerializeField] private EnemyEnum.EnemyType enemyType;
        private EnemyEnum.EnemyState _enemyState;
        private EnemyEnum.SpawnerType _spawnerType;
        private EnemyEnum.SpawnPoint _spawnPoint;

        [Header("Other")]
        [SerializeField] private Logger enemyLogger;
        private EnemyData _enemyData;

        [Header("Movement Settings")]
        private float _moveTime;
        private float _movingDirection;
        private Vector3 _movement;

        [Header("Attack Settings")]
        private bool _canAttack = true;

        [Header("Components")]
        private Transform _playerTransform;
        private FollowerEnemy _followerEnemy;

        //[Header("Controls")]

        protected override void Awake()
        {
            base.Awake();
            _enemyData = Managers.Instance.DataManager.EnemyData;

            _spawnPoint = transform.position.x > 0 ? EnemyEnum.SpawnPoint.Right : EnemyEnum.SpawnPoint.Left;
        }

        private void Start()
        {
            if (_spawnerType == EnemyEnum.SpawnerType.Multiple) _followerEnemy = transform.GetComponent<FollowerEnemy>();

            SetFeatures();

            enemyLogger = GameObject.Find("EnemyLogger").GetComponent<Logger>();

            _playerTransform = GameObject.FindWithTag("Player").transform;
            transform.LookAt(_playerTransform);

            _movingDirection = _spawnPoint == EnemyEnum.SpawnPoint.Left ? _movingDirection = -1 : _movingDirection = 1;

            SetEnemyState(EnemyEnum.EnemyState.Move);
        }

        private void Update()
        {
            switch (_enemyState)
            {
                case EnemyEnum.EnemyState.Move:
                    Move();
                    break;
                case EnemyEnum.EnemyState.Fire:
                    if (_canAttack) StartCoroutine(Attack(attackDelay));
                    break;
            }
        }

        private void SetFeatures()
        {
            switch (enemyType)
            {
                case EnemyEnum.EnemyType.SimpleEnemy:
                    if (_enemyState == EnemyEnum.EnemyState.Spawn) SetCharacterStats(_enemyData.SimpleEnemyMaxHealth, _enemyData.SimpleEnemyMovementSpeed, _enemyData.SimpleEnemyAttackDelay);
                    switch (_spawnerType)
                    {
                        case EnemyEnum.SpawnerType.Solo:
                            SetSoloEnemyStats(_enemyData.SimpleEnemyMinMoveTime, _enemyData.SimpleEnemyMaxMoveTime);
                            break;
                        case EnemyEnum.SpawnerType.Multiple:
                            StartCoroutine(SetMultipleEnemyStats());
                            break;
                    }

                    break;

                case EnemyEnum.EnemyType.BomberEnemy:
                    if (_enemyState == EnemyEnum.EnemyState.Spawn) SetCharacterStats(_enemyData.BomberEnemyMaxHealth, _enemyData.BomberEnemyMovementSpeed, _enemyData.BomberEnemyAttackDelay);
                    switch (_spawnerType)
                    {
                        case EnemyEnum.SpawnerType.Solo:
                            SetSoloEnemyStats(_enemyData.BomberEnemyMinMoveTime, _enemyData.BomberEnemyMaxMoveTime);
                            break;
                        case EnemyEnum.SpawnerType.Multiple:
                            StartCoroutine(SetMultipleEnemyStats());
                            break;
                    }

                    break;
                default:
                    Log("Not found enemy type");
                    break;
            }
        }

        #region State Setters

        private void SetEnemyState(EnemyEnum.EnemyState enemyState) => _enemyState = enemyState;
        public void SetEnemySpawnerType(EnemyEnum.SpawnerType spawnerType) => _spawnerType = spawnerType;

        #endregion


        public override void Move()
        {
            if (_enemyState != EnemyEnum.EnemyState.Move) return;

            if (_moveTime > 0)
            {
                Movement(speed);
                _moveTime -= Time.deltaTime;
            }

            if (_moveTime <= 0)
            {
                SetEnemyState(EnemyEnum.EnemyState.Fire);
            }
        }

        private IEnumerator Attack(float time)
        {
            _canAttack = false;
            if (_enemyState == EnemyEnum.EnemyState.Fire)
            {
                //
                yield return new WaitForSeconds(time);
                SetRandomState();
            }

            _canAttack = true;
        }

        private void Movement(float speedParam)
        {
            var tPos = transform.position;
            var tPosX = tPos.x + _movingDirection * Time.deltaTime * speedParam;

            transform.position = new Vector3(tPosX, tPos.y, tPos.z);
        }

        private void SetMoveDirection()
        {
            _movingDirection = _movingDirection switch
            {
                1 => -1,
                -1 => 1,
                _ => _movingDirection
            };
            transform.LookAt(_playerTransform);
        }

        private void SetRandomState()
        {
            var random = Random.Range(0, 2);
            switch (random)
            {
                case 0:
                    SetEnemyState(EnemyEnum.EnemyState.Fire);
                    break;
                case 1:
                    SetFeatures();
                    SetEnemyState(EnemyEnum.EnemyState.Move);
                    break;
            }
        }

        public override void Die()
        {
            SetEnemyState(EnemyEnum.EnemyState.Dead);
        }

        private void Log(object message)
        {
            if (enemyLogger) enemyLogger.Log(message, this);
        }

        private void SetMoveTime(float minTime, float maxTime)
        {
            _moveTime = Random.Range(minTime, maxTime);
        }

        private IEnumerator SetMultipleEnemyStats()
        {
            yield return new WaitForSeconds(.1f);
            _moveTime = _followerEnemy.LeadEnemyScript._moveTime;
            SetMoveDirection();
        }

        private void SetSoloEnemyStats(float minTime, float maxTime)
        {
            SetMoveTime(minTime, maxTime);
            SetMoveDirection();
        }
    } // END CLASS
}