using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "New Game Data")]
    public class GameData : ScriptableObject
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

        #region Screen Settings Getters

        /*public float LeftBorder { get; set; }
        public float RightBorder { get; set; }
        public float UpBorder { get; set; }
        public float DownBorder { get; set; }*/

        #endregion
    } // END CLASS
}