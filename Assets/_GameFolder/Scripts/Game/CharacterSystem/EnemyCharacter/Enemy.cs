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
        [SerializeField] private GameEnum.EnemyType enemyType;
        private GameEnum.EnemyState _enemyState;
        private GameEnum.SpawnerType _spawnerType;

        [Header("Other")]
        [SerializeField] private Logger enemyLogger;
        protected EnemyData EnemyData;

        [Header("Movement Settings")]
        private float _moveTime;

        private float _rotationSpeed;

        [Header("Components")]
        private Transform _targetTransform;

        protected override void Awake()
        {
            base.Awake();
            SetFeatures();
            EnemyData = Managers.Instance.DataManager.EnemyData;
        }

        private void Start()
        {
            enemyLogger = GameObject.Find("EnemyLogger").GetComponent<Logger>();

            _targetTransform = GameObject.FindWithTag("Player").transform;
            _rotationSpeed = EnemyData.RotationSpeed;

            SetEnemyState(GameEnum.EnemyState.Move);
        }

        private void Update()
        {
            //throw new NotImplementedException();
        }

        private void SetFeatures()
        {
            switch (enemyType)
            {
                case GameEnum.EnemyType.SimpleEnemy:
                    if (_enemyState == GameEnum.EnemyState.Spawn) SetCharacterStats(EnemyData.SimpleEnemyMaxHealth, EnemyData.SimpleEnemyMovementSpeed);
                    if (_spawnerType != GameEnum.SpawnerType.Multiple) SetMoveTime(EnemyData.SimpleEnemyMinMoveTime, EnemyData.SimpleEnemyMaxMoveTime);
                    break;
                case GameEnum.EnemyType.BomberEnemy:
                    if (_enemyState == GameEnum.EnemyState.Spawn) SetCharacterStats(EnemyData.BomberEnemyMaxHealth, EnemyData.BomberEnemyMovementSpeed);
                    if (_spawnerType != GameEnum.SpawnerType.Multiple) SetMoveTime(EnemyData.BomberEnemyMinMoveTime, EnemyData.BomberEnemyMaxMoveTime);
                    break;
                default:
                    Log("Not found enemy type");
                    break;
            }
        }

        private void SetEnemyState(GameEnum.EnemyState enemyState)
        {
            _enemyState = enemyState;
        }

        public void SetEnemySpawnerType(GameEnum.SpawnerType spawnerType)
        {
            _spawnerType = spawnerType;
        }

        public override void Move(float direction)
        {
            if (_enemyState == GameEnum.EnemyState.Move)
            {
                SetDirection();

                if (_moveTime > 0) Movement();

                _moveTime -= Time.deltaTime;
                if (_moveTime <= 0) SetFeatures();
            }

            base.Move(direction);
        }

        private void Fire()
        {
        }

        private void Movement()
        {
            if (_spawnerType == GameEnum.SpawnerType.Multiple)
            {
            }
        }

        private void SetDirection()
        {
            if (!_targetTransform) return;

            Vector3 directionToTarget = _targetTransform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        public override void Die()
        {
            base.Die();
            SetEnemyState(GameEnum.EnemyState.Dead);
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