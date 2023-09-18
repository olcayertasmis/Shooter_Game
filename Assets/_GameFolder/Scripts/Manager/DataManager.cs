using _GameFolder.Scripts.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GameFolder.Scripts.Manager
{
    [CreateAssetMenu(fileName = "Data Manager", menuName = "New Data Manager")]
    public class DataManager : ScriptableObject
    {
        [Header("Data")]
        [SerializeField] private MenuData menuData;
        [FormerlySerializedAs("gameData")] [SerializeField] private PlayerData playerData;
        [SerializeField] private EnemyData enemyData;
        [SerializeField] private EnemyListSo enemyListSo;
        [SerializeField] private EnemySpawnerData enemySpawnerData;

        #region Data Getters

        public MenuData MenuData => menuData;
        public PlayerData PlayerData => playerData;
        public EnemyData EnemyData => enemyData;
        public EnemyListSo EnemyListSo => enemyListSo;
        public EnemySpawnerData EnemySpawnerData => enemySpawnerData;

        #endregion
    } // END CLASS
}