using System;
using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Enums;
using _GameFolder.Scripts.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Spawner Settings")]
        private GameObject[] _enemyPrefabs;
        private Transform[] _spawnPoints;
        private float _spawnInterval;
        private float _currentTime;

        [Header("Data")]
        private GameData _gameData;

        private void Awake()
        {
            _gameData = Managers.Instance.DataManager.GameData;
        }

        private void Start()
        {
            _enemyPrefabs = _gameData.EnemyPrefabs;
            _spawnPoints = _gameData.EnemySpawnPoints;
            _spawnInterval = _gameData.SpawnInterval;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (!(_currentTime >= _spawnInterval)) return;
            SpawnEnemy();
            _currentTime = 0.0f;
        }

        private void SpawnEnemy()
        {
            if (_enemyPrefabs.Length == 0 || _spawnPoints.Length == 0)
            {
                return;
            }

            GameObject selectedEnemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];


            Transform selectedSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Vector3 spawnPosition = selectedSpawnPoint.position;

            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
            Enemy enemyScript = enemy.GetComponent<Enemy>();


            float spawnDirection = (spawnPosition.x < 0) ? 1.0f : -1.0f;
            
            //Spawnlanacağı hiearchy klasörünü de ayarla!
            //enemyScript.SetSpawnDirection(spawnDirection);

            // Rastgele move time ayarla
            //enemyScript.SetMoveTime(Random.Range(1.0f, 4.0f));
        }
    } // END CLASS
}