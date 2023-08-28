using UnityEngine;

namespace _GameFolder.Scripts.Enums
{
    public class SceneEnum : MonoBehaviour
    {
        public enum SceneName
        {
            Menu,
            LoadingScene,
            Game
        }

        public static string GetLoadingSceneName => SceneName.LoadingScene.ToString();
    } // END CLASS
}