using UnityEngine;
using Object = UnityEngine.Object;

namespace _GameFolder.Scripts.Services
{
    public class Logger : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool showLogs;
        [SerializeField] private string prefix;
        [SerializeField] private Color prefixColor;


        private void OnValidate()
        {
            _hexColor = "#" + ColorUtility.ToHtmlStringRGBA(prefixColor);
        }

        public void Log(object message, Object sender)
        {
            if (!showLogs) return;
            Debug.Log($"<color={_hexColor}>{prefix}: {message}</color>", sender);
        }

        private string _hexColor;
    } // END CLASS
}