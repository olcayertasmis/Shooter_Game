using System.Collections;
using _GameFolder.Scripts.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _GameFolder.Scripts
{
    public class LoadingScene : MonoBehaviour
    {
        [SerializeField] private Slider loadingSlider;
        [SerializeField] private TMP_Text loadingText;

        private void Start()
        {
            StartCoroutine(IELoadScene());
        }

        private IEnumerator IELoadScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(Managers.Instance.LoadingManager.sceneToLoad);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                var progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                print(asyncLoad.progress);
                loadingSlider.value = progress;
                loadingText.text = "Loading: " + (progress * 100f).ToString("F0") + "%";

                if (progress >= 1f)
                {
                    yield return new WaitForSeconds(1f);
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    } // END CLASS
}