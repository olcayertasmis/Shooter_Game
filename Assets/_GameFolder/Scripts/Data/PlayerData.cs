using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "New Player Data")]
    public class PlayerData : ScriptableObject
    {
        [Header("Player Stats")]
        [SerializeField] private int playerMaxHealth;
        [SerializeField] private float playerMovementSpeed;

        [Header("Attack Settings")]
        [SerializeField] private float playerAttackDelay;
        [SerializeField] private float fireRange;

        [Header("Crosshair Settings")]
        [SerializeField] private float crosshairSpeed;
        [SerializeField] private LayerMask crosshairLayerMask;


        #region Player Getters

        public int PlayerMaxHealth => playerMaxHealth;
        public float PlayerMovementSpeed => playerMovementSpeed;
        public float PlayerAttackDelay => playerAttackDelay;
        public float CrosshairSpeed => crosshairSpeed;
        public LayerMask CrosshairLayerMask => crosshairLayerMask;
        public float FireRange => fireRange;

        #endregion
    } // END CLASS
}