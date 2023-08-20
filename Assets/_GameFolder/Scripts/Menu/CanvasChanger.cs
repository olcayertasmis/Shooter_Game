using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _GameFolder.Scripts.Menu
{
    public class CanvasChanger : MonoBehaviour
    {
        [SerializeField] private float waitForSeconds;

        public void ShowCanvas(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 0f, 1f, true));
        }

        public void HideCanvas(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 1f, 0f, false));
        }

        private IEnumerator ProcessCanvasGroup(CanvasGroup canvasGroup, float initAlpha, float alpha, bool enable)
        {
            canvasGroup.alpha = initAlpha;
            if (enable) canvasGroup.gameObject.SetActive(true);
            yield return new WaitForSeconds(waitForSeconds);
            canvasGroup.DOFade(alpha, 0.3f);
            yield return new WaitForSeconds(waitForSeconds);
            canvasGroup.gameObject.SetActive(enable);
        }
    }
}