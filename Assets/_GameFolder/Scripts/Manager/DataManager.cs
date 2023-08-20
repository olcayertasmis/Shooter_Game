using _GameFolder.Scripts.Data;
using UnityEngine;

namespace _GameFolder.Scripts.Manager
{
    [CreateAssetMenu(fileName = "Data Manager", menuName = "New Data Manager")]
    public class DataManager : ScriptableObject
    {
        [SerializeField] private MenuData menuData;
        [SerializeField] private GameData gameData;

        public MenuData MenuData => menuData;
        public GameData GameData => gameData;
    }
}