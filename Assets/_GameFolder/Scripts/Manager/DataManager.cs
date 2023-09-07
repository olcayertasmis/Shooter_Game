using _GameFolder.Scripts.Data;
using UnityEngine;

namespace _GameFolder.Scripts.Manager
{
    [CreateAssetMenu(fileName = "Data Manager", menuName = "New Data Manager")]
    public class DataManager : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private MenuData menuData;
        [SerializeField] private GameData gameData;
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private EnemyListSo enemyListSo;
        [SerializeField] private EnemySpawnerData enemySpawnerData;

        #region Data Getters

        public MenuData MenuData => menuData;
        public GameData GameData => gameData;
        public EnemyData EnemyData => enemyData;
        public EnemyListSo EnemyListSo => enemyListSo;
        public EnemySpawnerData EnemySpawnerData => enemySpawnerData;

        #endregion
    } // END CLASS
}