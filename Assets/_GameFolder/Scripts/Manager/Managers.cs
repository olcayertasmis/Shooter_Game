using _GameFolder.Scripts.SingletonSystem;
using UnityEngine;

namespace _GameFolder.Scripts.Manager
{
    public class Managers : Singleton<Managers>
    {
        [SerializeField] private MenuUIManager menuUIManager;
        [SerializeField] private DataManager dataManager;
        [SerializeField] private GameManager gameManager;

        public MenuUIManager MenuUIManager => menuUIManager;
        public DataManager DataManager => dataManager;
        public GameManager GameManager => gameManager;
    }
}