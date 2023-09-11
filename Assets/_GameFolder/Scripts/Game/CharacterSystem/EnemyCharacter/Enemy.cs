using System;
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
        private float _rotationSpeed;
        private float _movingDirection;
        private Vector3 _movement;

        [Header("Components")]
        private Transform _playerTransform;

        protected override void Awake()
        {
            base.Awake();
            _enemyData = Managers.Instance.DataManager.EnemyData;
            SetFeatures();
        }

        private void Start()
        {
            enemyLogger = GameObject.Find("EnemyLogger").GetComponent<Logger>();

            _playerTransform = GameObject.FindWithTag("Player").transform;
            transform.LookAt(_playerTransform);

            _rotationSpeed = _enemyData.RotationSpeed;

            _movingDirection = _spawnPoint == EnemyEnum.SpawnPoint.Left ? _movingDirection = 0 : _movingDirection = 1;

            SetEnemyState(EnemyEnum.EnemyState.Move);
        }

        private void Update()
        {
            Move();
            Fire();
        }

        private void SetFeatures()
        {
            switch (enemyType)
            {
                case EnemyEnum.EnemyType.SimpleEnemy:
                    if (_enemyState == EnemyEnum.EnemyState.Spawn) SetCharacterStats(_enemyData.SimpleEnemyMaxHealth, _enemyData.SimpleEnemyMovementSpeed);
                    if (_spawnerType != EnemyEnum.SpawnerType.Multiple)
                    {
                        SetMoveTime(_enemyData.SimpleEnemyMinMoveTime, _enemyData.SimpleEnemyMaxMoveTime);
                        SetMoveDirection();
                    }

                    break;
                case EnemyEnum.EnemyType.BomberEnemy:
                    if (_enemyState == EnemyEnum.EnemyState.Spawn) SetCharacterStats(_enemyData.BomberEnemyMaxHealth, _enemyData.BomberEnemyMovementSpeed);
                    if (_spawnerType != EnemyEnum.SpawnerType.Multiple)
                    {
                        SetMoveTime(_enemyData.BomberEnemyMinMoveTime, _enemyData.BomberEnemyMaxMoveTime);
                        SetMoveDirection();
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
        public void SetEnemySpawnPoint(EnemyEnum.SpawnPoint spawnPoint) => _spawnPoint = spawnPoint;

        #endregion


        public override void Move()
        {
            if (_enemyState != EnemyEnum.EnemyState.Move) return;

            if (_moveTime > 0) Movement(_speed);

            _moveTime -= Time.deltaTime;
            if (!(_moveTime <= 0)) return;
            Fire();
            SetMoveDirection();
            SetFeatures();
        }

        private void Fire()
        {
            SetEnemyState(EnemyEnum.EnemyState.Fire);

            if (_enemyState != EnemyEnum.EnemyState.Fire) return;

            //

            SetRandomState();
        }

        private void Movement(float speed)
        {
            if (_spawnerType == EnemyEnum.SpawnerType.Multiple)
            {
            }
            else
            {
                //_movement = new Vector3(_movingDirection, 0.0f, 0.0f) * (speed * Time.deltaTime);
                //transform.Translate(_movement);

                var tPos = transform.position;
                var tPosX = tPos.x + _movingDirection * Time.deltaTime * speed;

                transform.position = new Vector3(tPosX, tPos.y, tPos.z);
            }
        }

        private void SetMoveDirection()
        {
            _movingDirection = _movingDirection switch
            {
                0 => 1,
                1 => 0,
                _ => _movingDirection
            };
            transform.LookAt(_playerTransform);
        }

        private void SetRandomState()
        {
            var random = Random.Range(0, 2);
            switch (random)
            {
                case 1:
                    SetEnemyState(EnemyEnum.EnemyState.Fire);
                    break;
                case 2:
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

        public float GetMoveTime => _moveTime;

        public void SetMoveTime(float moveTime)
        {
            _moveTime = moveTime;
        }
    } // END CLASS
}