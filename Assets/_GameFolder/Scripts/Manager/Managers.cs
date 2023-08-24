using _GameFolder.Scripts.SingletonSystem;
using UnityEngine;

namespace _GameFolder.Scripts.Manager
{
    public class Managers : Singleton<Managers>
    {
        [Header("Identifiers")]
        [SerializeField] private MenuUIManager menuUIManager;
        [SerializeField] private DataManager dataManager;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private LoadingManager loadingManager;


        #region Getters

        public MenuUIManager MenuUIManager => menuUIManager;
        public DataManager DataManager => dataManager;
        public GameManager GameManager => gameManager;
        public LoadingManager LoadingManager => loadingManager;

        #endregion
    } // END CLASS
}