using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Enemy Spawner Data", menuName = "New Enemy Spawner Data")]
    public class EnemySpawnerData : ScriptableObject
    {
        [Header("Enemy Spawner Settings")]
        [SerializeField] private float spawnInterval;
        [SerializeField] private string enemyParentPath;
        [SerializeField] private Transform[] enemySpawnPoints;
        [SerializeField] private int minSpawnPointZ, maxSpawnPointZ;

        [Header("Multiple Spawner Settings")]
        [SerializeField] private int maxMultipleSpawnCount;
        [SerializeField] private float multipleSpawnTime;


        #region Enemy Spawner Getters

        public float SpawnInterval => spawnInterval;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;

        public List<Transform> SpawnedEnemyList { get; set; }
        public string EnemyParentPath => enemyParentPath;
        public int MinSpawnPointZ => minSpawnPointZ;
        public int MaxSpawnPointZ => maxSpawnPointZ;

        #endregion

        #region Multiple Enemy Spawner Getters

        public int MaxMultipleSpawnCount => maxMultipleSpawnCount;
        public float MultipleSpawnTime => multipleSpawnTime;

        #endregion
    }
}