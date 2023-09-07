using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Enemy List SO", menuName = "New Enemy List SO")]
    public class EnemyListSo : ScriptableObject
    {
        [Header("Enemy List")]
        [SerializeField] private GameObject[] enemyPrefabs;

        #region Getters

        public GameObject[] EnemyPrefabs => enemyPrefabs;

        #endregion
    }
}