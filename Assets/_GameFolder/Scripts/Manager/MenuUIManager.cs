using System.Collections.Generic;
using _GameFolder.Scripts.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace _GameFolder.Scripts.Manager
{
    public class MenuUIManager : MonoBehaviour
    {
        [Header("Background")]
        [SerializeField] private Image backgroundImage;

        [Header("Canvas Group")]
        [SerializeField] private List<CanvasGroup> allCanvasGroups; // Main Menu Panel hariç hepsi (açık kalması istenilen hariç hepsi)

        #region Getters

        #region Background Getters

        public Image BackgroundImage => backgroundImage;

        #endregion

        #region Canvas Getters

        public List<CanvasGroup> AllCanvasGroups => allCanvasGroups;

        #endregion

        #endregion


        #region Functions

        public void LoadGameScene()
        {
            Managers.Instance.LoadingManager.LoadSceneWithLoading(SceneEnum.SceneName.Game);
        }

        #endregion
    } // END CLASS
}