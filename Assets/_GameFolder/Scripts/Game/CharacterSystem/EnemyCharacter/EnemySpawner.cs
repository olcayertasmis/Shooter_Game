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
        private Transform _parentTransform;
        private float _currentTime;
        private bool _canSpawn = true;

        [Header("Spawner Settings W-Game Data")]
        private GameObject[] _enemyPrefabs;
        private Transform[] _spawnPoints;
        private float _spawnInterval;
        private int _maxMultipleSpawnCount;
        private float _multipleSpawnTime;

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
            _maxMultipleSpawnCount = _gameData.MaxMultipleSpawnCount;
            _multipleSpawnTime = _gameData.MultipleSpawnTime;

            _parentTransform = GameObject.Find("/GAME/Enemies").transform;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_multipleSpawnTime >= 0) _multipleSpawnTime -= Time.deltaTime;

            if (!(_currentTime >= _spawnInterval) && _multipleSpawnTime >= 0) return;
            Spawner();
        }

        private void Spawner()
        {
            if (_enemyPrefabs.Length == 0 || _spawnPoints.Length == 0)
            {
                return;
            }

            if (_multipleSpawnTime <= 0)
            {
                var spawnerType = (SpawnerType)Random.Range(0, Enum.GetValues(typeof(SpawnerType)).Length);

                switch (spawnerType)
                {
                    case SpawnerType.Multiple:
                    {
                        var multipleSpawnCount = Random.Range(2, _maxMultipleSpawnCount + 1);

                        SpawnEnemy();
                        _canSpawn = false;

                        for (int i = 0; i < multipleSpawnCount; i++)
                        {
                            var lastSpawnedEnemy = _gameData.EnemiesList[^1];
                            var lastEnemySpawnedPosition = lastSpawnedEnemy.position;
                            Vector3 spawnPosition;
                            if (lastEnemySpawnedPosition.x > 0)
                            {
                                spawnPosition = new Vector3(lastEnemySpawnedPosition.x + 2, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z);
                            }
                            else
                            {
                                spawnPosition = new Vector3(lastEnemySpawnedPosition.x - 2, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z);
                            }

                            var duplicatedEnemy = Instantiate(lastSpawnedEnemy, spawnPosition, Quaternion.identity);
                            _gameData.EnemiesList.Add(duplicatedEnemy);
                            duplicatedEnemy.SetParent(_parentTransform);
                        }

                        _canSpawn = true;
                        _multipleSpawnTime = _gameData.MultipleSpawnTime;
                        break;
                    }
                    case SpawnerType.Solo:
                        SpawnEnemy();
                        break;
                }
            }
            else
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            if (!_canSpawn) return;

            GameObject selectedEnemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];


            Transform selectedSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            Vector3 spawnPosition = selectedSpawnPoint.position;

            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
            _gameData.EnemiesList.Add(enemy.transform);
            enemy.transform.SetParent(_parentTransform);


            Enemy enemyScript = enemy.GetComponent<Enemy>();

            enemyScript.SetEnemyState(GameEnum.EnemyState.Spawn);

            _currentTime = 0.0f;
        }

        private enum SpawnerType
        {
            Solo,
            Multiple
        }
    } // END CLASS
}