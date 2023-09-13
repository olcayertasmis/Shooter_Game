using System;
using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Enums;
using _GameFolder.Scripts.Manager;
using Unity.VisualScripting;
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
        private bool _isLeaderEnemy;
        private GameObject _leaderEnemyPrefab;
        private GameObject _leaderEnemyGo;

        [Header("Spawner Settings W-Game Data")]
        private GameObject[] _enemyPrefabs;
        private float _multipleSpawnTime;

        [Header("Data")]
        private EnemySpawnerData _enemySpawnerData;
        private EnemyListSo _enemyListSo;

        [Header("Components")]
        private Camera cam;

        private void Awake()
        {
            var dataManager = Managers.Instance.DataManager;
            _enemySpawnerData = dataManager.EnemySpawnerData;
            _enemyListSo = dataManager.EnemyListSo;

            _enemySpawnerData.SpawnedEnemyList.Clear();

            cam = Camera.main;
        }

        private void Start()
        {
            _enemyPrefabs = _enemyListSo.EnemyPrefabs;
            _multipleSpawnTime = _enemySpawnerData.MultipleSpawnTime;

            _parentTransform = GameObject.Find(_enemySpawnerData.EnemyParentPath).transform;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_multipleSpawnTime >= 0) _multipleSpawnTime -= Time.deltaTime;

            if (_currentTime < _enemySpawnerData.SpawnInterval) return;
            Spawner();
        }

        private void Spawner()
        {
            if (_enemyPrefabs.Length == 0) return;

            var spawnerType = (EnemyEnum.SpawnerType)Random.Range(0, Enum.GetValues(typeof(EnemyEnum.SpawnerType)).Length);

            if (spawnerType == EnemyEnum.SpawnerType.Multiple && _multipleSpawnTime > 0) return;

            switch (spawnerType)
            {
                case EnemyEnum.SpawnerType.Multiple:
                {
                    var multipleSpawnCount = Random.Range(2, _enemySpawnerData.MaxMultipleSpawnCount);

                    _isLeaderEnemy = true;
                    SpawnEnemy();
                    _canSpawn = false;

                    _leaderEnemyGo.transform.AddComponent<LeaderEnemy>();

                    for (int i = 0; i < multipleSpawnCount; i++)
                    {
                        var lastSpawnedEnemy = _enemySpawnerData.SpawnedEnemyList[^1];
                        var lastEnemySpawnedPosition = lastSpawnedEnemy.position;
                        var spawnPosition = lastEnemySpawnedPosition.x > 0
                            ? new Vector3(lastEnemySpawnedPosition.x + 4, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z)
                            : new Vector3(lastEnemySpawnedPosition.x - 4, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z);

                        var duplicatedEnemy = Instantiate(_leaderEnemyPrefab, spawnPosition, Quaternion.identity);
                        duplicatedEnemy.transform.SetParent(_parentTransform);

                        var followerEnemyScript = duplicatedEnemy.transform.AddComponent<FollowerEnemy>();
                        followerEnemyScript.SetLeadEnemy(_leaderEnemyGo.transform);

                        var enemyScript = duplicatedEnemy.transform.GetComponent<Enemy>();
                        enemyScript.SetEnemySpawnerType(EnemyEnum.SpawnerType.Multiple);

                        _enemySpawnerData.SpawnedEnemyList.Add(duplicatedEnemy.transform);
                    }

                    _isLeaderEnemy = false;
                    _canSpawn = true;
                    _currentTime = 0f;
                    _multipleSpawnTime = _enemySpawnerData.MultipleSpawnTime;
                    break;
                }
                case EnemyEnum.SpawnerType.Solo:
                    SpawnEnemy();
                    _currentTime = 0f;
                    break;
            }
        }

        private void SpawnEnemy()
        {
            if (!_canSpawn) return;

            GameObject selectedEnemyPrefab = _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)];


            Vector3 spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), 0f, Random.Range(_enemySpawnerData.MinSpawnPointZ, _enemySpawnerData.MaxSpawnPointZ)));
            spawnPosition.y = 0;

            spawnPosition.x = spawnPosition.x > 0 ? spawnPosition.x += 2f : spawnPosition.x -= 2f;

            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
            if (_isLeaderEnemy)
            {
                _leaderEnemyPrefab = selectedEnemyPrefab;
                _leaderEnemyGo = enemy;
            }

            _enemySpawnerData.SpawnedEnemyList.Add(enemy.transform);
            enemy.transform.SetParent(_parentTransform);
        }
    } // END CLASS
}