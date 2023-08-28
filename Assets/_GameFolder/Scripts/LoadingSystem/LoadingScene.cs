using System.Collections;
using _GameFolder.Scripts.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _GameFolder.Scripts.LoadingSystem
{
    public class LoadingScene : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Slider loadingSlider;
        [SerializeField] private TMP_Text loadingText;

        [Header("Control")]
        private bool _canAsyncLoad;

        private void Start()
        {
            StartCoroutine(IELoadScene());
        }

        private void UpdateUIContent(float progress)
        {
            loadingSlider.value = progress;
            loadingText.text = "Loading: " + (progress * 100f).ToString("F0") + "%";
        }

        private IEnumerator IELoadScene()
        {
            var asyncLoad = SceneManager.LoadSceneAsync(Managers.Instance.LoadingManager.sceneToLoad);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                var progress = Mathf.Clamp01(asyncLoad.progress);

                UpdateUIContent(progress);

                if (progress >= .9f)
                {
                    yield return new WaitForSeconds(.25f);
                    progress = Mathf.Clamp01(asyncLoad.progress / .9f);

                    yield return new WaitForSeconds(.1f);
                    UpdateUIContent(progress);
                    _canAsyncLoad = true;
                }

                if (progress >= 1f && _canAsyncLoad)
                {
                    yield return new WaitForSeconds(.1f);
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    } // END CLASS
}