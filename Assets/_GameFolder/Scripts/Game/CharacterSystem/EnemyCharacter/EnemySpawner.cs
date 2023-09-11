using System;
using System.Xml.Linq;
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
        //private bool _onRight = false;

        [Header("Spawner Settings W-Game Data")]
        private GameObject[] _enemyPrefabs;
        private Transform[] _spawnPoints;
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
            _spawnPoints = _enemySpawnerData.EnemySpawnPoints;
            _multipleSpawnTime = _enemySpawnerData.MultipleSpawnTime;

            _parentTransform = GameObject.Find(_enemySpawnerData.EnemyParentPath).transform;
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_multipleSpawnTime >= 0) _multipleSpawnTime -= Time.deltaTime;

            if (!(_currentTime >= _enemySpawnerData.SpawnInterval) && _multipleSpawnTime >= 0) return;
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
                var spawnerType = (EnemyEnum.SpawnerType)Random.Range(0, Enum.GetValues(typeof(EnemyEnum.SpawnerType)).Length);

                switch (spawnerType)
                {
                    case EnemyEnum.SpawnerType.Multiple:
                    {
                        var multipleSpawnCount = Random.Range(2, _enemySpawnerData.MaxMultipleSpawnCount);

                        SpawnEnemy();
                        _canSpawn = false;


                        for (int i = 0; i < multipleSpawnCount; i++)
                        {
                            var lastSpawnedEnemy = _enemySpawnerData.SpawnedEnemyList[^1];
                            var lastEnemySpawnedPosition = lastSpawnedEnemy.position;
                            var spawnPosition = lastEnemySpawnedPosition.x > 0
                                ? new Vector3(lastEnemySpawnedPosition.x + 2, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z)
                                : new Vector3(lastEnemySpawnedPosition.x - 2, lastEnemySpawnedPosition.y, lastEnemySpawnedPosition.z);

                            var duplicatedEnemy = Instantiate(lastSpawnedEnemy, spawnPosition, Quaternion.identity);
                            _enemySpawnerData.SpawnedEnemyList.Add(duplicatedEnemy);
                            duplicatedEnemy.SetParent(_parentTransform);
                            Enemy enemyScript = duplicatedEnemy.GetComponent<Enemy>();
                            enemyScript.SetEnemySpawnerType(EnemyEnum.SpawnerType.Multiple);
                            enemyScript.SetMoveTime(lastSpawnedEnemy.GetComponent<Enemy>().GetMoveTime);
                        }

                        _canSpawn = true;
                        _multipleSpawnTime = _enemySpawnerData.MultipleSpawnTime;
                        break;
                    }
                    case EnemyEnum.SpawnerType.Solo:
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

            Vector3 spawnPosition = cam.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), 0f, Random.Range(_enemySpawnerData.MinSpawnPointZ, _enemySpawnerData.MaxSpawnPointZ)));
            spawnPosition.y = 0;

            spawnPosition.x = spawnPosition.x > 0 ? spawnPosition.x += 2f : spawnPosition.x -= 2f;

            GameObject enemy = Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            enemyScript.SetEnemySpawnPoint(spawnPosition.x > 0 ? EnemyEnum.SpawnPoint.Right : EnemyEnum.SpawnPoint.Left);


            _enemySpawnerData.SpawnedEnemyList.Add(enemy.transform);
            enemy.transform.SetParent(_parentTransform);

            _currentTime = 0.0f;
        }
    } // END CLASS
}