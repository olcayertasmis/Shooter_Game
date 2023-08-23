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

        #region Data Getters

        public MenuData MenuData => menuData;
        public GameData GameData => gameData;

        #endregion
    } // END CLASS
}