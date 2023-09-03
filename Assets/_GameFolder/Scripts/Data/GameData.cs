using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "New Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Player Stats")]
        [SerializeField] private int playerMaxHealth;
        [SerializeField] private float playerMovementSpeed;

        [Header("Enemy Stats")]
        [SerializeField] private int simpleEnemyMaxHealth;
        [SerializeField] private float simpleEnemyMovementSpeed;

        [Header("Enemy Spawner Settings")]
        [SerializeField] private float spawnInterval;
        [SerializeField] private GameObject[] enemyPrefabs;
        [SerializeField] private Transform[] enemySpawnPoints;

        #region Player Getters

        public int PlayerMaxHealth => playerMaxHealth;
        public float PlayerMovementSpeed => playerMovementSpeed;

        #endregion

        #region Enemy Stats Getters

        public int SimpleEnemyMaxHealth => simpleEnemyMaxHealth;
        public float SimpleEnemyMovementSpeed => simpleEnemyMovementSpeed;

        #endregion

        #region Enemy Spawner Getters

        public float SpawnInterval => spawnInterval;
        public GameObject[] EnemyPrefabs => enemyPrefabs;
        public Transform[] EnemySpawnPoints => enemySpawnPoints;

        #endregion
    } // END CLASS
}