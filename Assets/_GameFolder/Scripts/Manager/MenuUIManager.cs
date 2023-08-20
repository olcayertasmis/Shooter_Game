using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.SingletonSystem;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _GameFolder.Scripts.Manager
{
    public class MenuUIManager : MonoBehaviour
    {
        [SerializeField] private Image backgroundImage;

        public Image BackgroundImage => backgroundImage;
    }
}