using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "New Game Data")]
    public class GameData : ScriptableObject
    {
        [Header("Player Stats")]
        [SerializeField] private int playerMaxHealth;
        [SerializeField] private float playerMovementSpeed;

        [Header("Enemy Stats")]
        [SerializeField] private int enemyMaxHealth;
        [SerializeField] private float enemyMovementSpeed;

        #region Player Getters

        public int PlayerMaxHealth => playerMaxHealth;
        public float PlayerMovementSpeed => playerMovementSpeed;

        #endregion

        #region Enemy Getters

        public int EnemyMaxHealth => enemyMaxHealth;
        public float EnemyMovementSpeed => enemyMovementSpeed;

        #endregion
    } // END CLASS
}