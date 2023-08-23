using System.Collections.Generic;
using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Menu Data", menuName = "New Menu Data")]
    public class MenuData : ScriptableObject
    {
        [Header("Background")]
        [SerializeField] private float transitionDuration;
        [SerializeField] private float autoTransitionInterval;
        [SerializeField] private List<Sprite> backgroundSprites;

        [Header("Canvas Settings")]
        [SerializeField] private float canvasTransitionWaitForSeconds;


        #region Background Getters

        public List<Sprite> BackgroundSprites => backgroundSprites;
        public float TransitionDuration => transitionDuration;
        public float AutoTransitionInterval => autoTransitionInterval;

        #endregion


        #region Canvas Getters

        public float CanvasTransitionWaitForSeconds => canvasTransitionWaitForSeconds;

        #endregion
    } // END CLASS
}