using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "New Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Player Stats")]
        [SerializeField] private int playerMaxHealth;
        [SerializeField] private float playerMovementSpeed;
        [SerializeField] private float playerAttackDelay;


        #region Player Getters

        public int PlayerMaxHealth => playerMaxHealth;
        public float PlayerMovementSpeed => playerMovementSpeed;
        public float PlayerAttackDelay => playerAttackDelay;

        #endregion
    } // END CLASS
}