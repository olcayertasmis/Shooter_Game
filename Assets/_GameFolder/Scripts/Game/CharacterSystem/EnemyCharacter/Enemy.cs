using _GameFolder.Scripts.Enums;
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

        [Header("Other")]
        [SerializeField] private Logger enemyLogger;

        [Header("Movement Settings")]
        private float _moveTime;

        private void Start()
        {
            enemyLogger = GameObject.Find("EnemyLogger").GetComponent<Logger>();

            SetFeatures();

            SetEnemyState(GameEnum.EnemyState.Move);
        }

        private void SetFeatures()
        {
            switch (enemyType)
            {
                case GameEnum.EnemyType.SimpleEnemy:
                    if (_enemyState == GameEnum.EnemyState.Spawn) SetCharacterStats(GameData.SimpleEnemyMaxHealth, GameData.SimpleEnemyMovementSpeed);
                    SetMoveTime(GameData.SimpleEnemyMinMoveTime, GameData.SimpleEnemyMaxMoveTime);
                    break;
                case GameEnum.EnemyType.BomberEnemy:
                    if (_enemyState == GameEnum.EnemyState.Spawn) SetCharacterStats(GameData.BomberEnemyMaxHealth, GameData.BomberEnemyMovementSpeed);
                    SetMoveTime(GameData.BomberEnemyMinMoveTime, GameData.BomberEnemyMaxMoveTime);
                    break;
                default:
                    Log("Not found enemy type");
                    break;
            }
        }

        public void SetEnemyState(GameEnum.EnemyState enemyState)
        {
            _enemyState = enemyState;
        }

        public override void Move(float direction)
        {
            if (_enemyState == GameEnum.EnemyState.Move)
            {
                _moveTime -= Time.deltaTime;
                if (_moveTime <= 0) SetFeatures();
            }

            base.Move(direction);
        }

        private void Log(object message)
        {
            if (enemyLogger) enemyLogger.Log(message, this);
        }

        private void SetMoveTime(float minTime, float maxTime)
        {
            _moveTime = Random.Range(minTime, maxTime);
        }
    } // END CLASS
}