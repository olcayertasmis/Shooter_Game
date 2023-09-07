using System.Collections.Generic;
using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Enemy Spawner Data", menuName = "New Enemy Spawner Data")]
    public class EnemySpawnerData : ScriptableObject
    {
        [Header("Enemy Spawner Settings")]
        [SerializeField] private float spawnInterval;
        [SerializeField] private int maxMultipleSpawnCount;
        [SerializeField] private float multipleSpawnTime;
        [SerializeField] private Transform[] enemySpawnPoints;
        [SerializeField] private string enemyParentPath;
        private List<Transform> _spawnedEnemyList;


        #region Enemy Spawner Getters

        public float SpawnInterval => spawnInterval;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;
        public int MaxMultipleSpawnCount => maxMultipleSpawnCount;
        public float MultipleSpawnTime => multipleSpawnTime;
        public List<Transform> SpawnedEnemyList => _spawnedEnemyList;
        public string EnemyParentPath => enemyParentPath;

        #endregion
    }
}