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

        public enum EnemyState
        {
            Spawn,
            Move,
            Fire,
            Dead
        }

        public enum SpawnerType
        {
            Solo,
            Multiple
        }

        public enum SpawnPoint
        {
            Left,
            Right
        }
    } // END CLASS
}