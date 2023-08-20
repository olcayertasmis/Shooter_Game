using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Menu Data", menuName = "New Menu Data")]
    public class MenuData : ScriptableObject
    {
        [Header("BackGround")]
        [SerializeField] private float transitionDuration;
        [SerializeField] private float autoTransitionInterval;
        [SerializeField] private List<Sprite> backgroundSprites;

        public List<Sprite> BackgroundSprites => backgroundSprites;
        public float TransitionDuration => transitionDuration;
        public float AutoTransitionInterval => autoTransitionInterval;
    }
}