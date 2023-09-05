using System.Collections.Generic;
using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "New Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Player Stats")]
        [SerializeField] private int playerMaxHealth;
        [SerializeField] private float playerMovementSpeed;

        [Header("Enemy Stats")]
        [Header("Simple Enemy Stats")]
        [SerializeField] private int simpleEnemyMaxHealth;
        [SerializeField] private float simpleEnemyMovementSpeed;
        [SerializeField] private float simpleEnemyMinMoveTime, simpleEnemyMaxMoveTime;
        [Header("Bomber Enemy Stats")]
        [SerializeField] private int bomberEnemyMaxHealth;
        [SerializeField] private float bomberEnemyMovementSpeed;
        [SerializeField] private float bomberEnemyMinMoveTime, bomberEnemyMaxMoveTime;

        [Header("Enemy Spawner Settings")]
        [SerializeField] private float spawnInterval;
        [SerializeField] private int maxMultipleSpawnCount;
        [SerializeField] private float multipleSpawnTime;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] enemySpawnPoints;
        private List<Transform> _enemiesList;


        #region Player Getters

        public int PlayerMaxHealth => playerMaxHealth;
        public float PlayerMovementSpeed => playerMovementSpeed;

        #endregion

        #region Enemy Getters

        #region Enemy Stats Getters

        #region Simple Enemy Stats Getters

        public int SimpleEnemyMaxHealth => simpleEnemyMaxHealth;
        public float SimpleEnemyMovementSpeed => simpleEnemyMovementSpeed;
        public float SimpleEnemyMinMoveTime => simpleEnemyMinMoveTime;
        public float SimpleEnemyMaxMoveTime => simpleEnemyMaxMoveTime;

        #endregion

        #region Bomber Enemy Stats Getters

        public int BomberEnemyMaxHealth => bomberEnemyMaxHealth;
        public float BomberEnemyMovementSpeed => bomberEnemyMovementSpeed;
        public float BomberEnemyMinMoveTime => bomberEnemyMinMoveTime;
        public float BomberEnemyMaxMoveTime => bomberEnemyMaxMoveTime;

        #endregion

        #endregion

        #region Enemy Spawner Getters

        public float SpawnInterval => spawnInterval;
        public GameObject[] EnemyPrefabs => enemyPrefabs;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;
        public int MaxMultipleSpawnCount => maxMultipleSpawnCount;
        public float MultipleSpawnTime => multipleSpawnTime;
        public List<Transform> EnemiesList => _enemiesList;

        #endregion

        #endregion
    } // END CLASS
}