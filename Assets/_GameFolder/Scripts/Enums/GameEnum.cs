using UnityEngine;

namespace _GameFolder.Scripts.Enums
{
    public class GameEnum : MonoBehaviour
    {
        public enum GameState
        {
            Menu,
            Play,
            Dead
        }

        public enum EnemyType
        {
            SimpleEnemy,
            BomberEnemy
        }
    } // END CLASS
}