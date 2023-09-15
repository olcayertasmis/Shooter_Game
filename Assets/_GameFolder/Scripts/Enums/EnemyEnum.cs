using UnityEngine;

namespace _GameFolder.Scripts.Enums
{
    public class EnemyEnum : MonoBehaviour
    {
        public enum EnemyType
        {
            SimpleEnemy,
            BomberEnemy
        }

        public enum EnemyState
        {
            Spawn,
            Move,
            Attack,
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