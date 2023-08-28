using _GameFolder.Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameFolder.Scripts.Manager
{
    public class LoadingManager : MonoBehaviour
    {
        public string sceneToLoad;

        public void LoadSceneWithLoading(SceneEnum.SceneName sceneName)
        {
            sceneToLoad = sceneName.ToString();
            SceneManager.LoadScene(SceneEnum.GetLoadingSceneName);
        }
    } // END CLASS
}