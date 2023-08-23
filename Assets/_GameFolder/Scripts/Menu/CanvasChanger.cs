using System.Collections;
using _GameFolder.Scripts.Manager;
using DG.Tweening;
using UnityEngine;

namespace _GameFolder.Scripts.Menu
{
    public class CanvasChanger : MonoBehaviour
    {
        [Header("Canvas Settings")]
        private float _canvasTransitionWaitForSeconds;

        private void Start()
        {
            _canvasTransitionWaitForSeconds = Managers.Instance.DataManager.MenuData.CanvasTransitionWaitForSeconds;
        }

        public void ShowCanvas(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 0f, 1f, true, true));
        }

        public void HideCanvas(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 1f, 0f, false, false));
        }

        public void HideMenuPanel(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 1f, .1f, true, false));
        }

        public void ShowMenuPanel(CanvasGroup canvasGroup)
        {
            StartCoroutine(ProcessCanvasGroup(canvasGroup, 0f, 1f, true, true));
        }

        private IEnumerator ProcessCanvasGroup(CanvasGroup canvasGroup, float initAlpha, float alpha, bool enable, bool interactable)
        {
            canvasGroup.alpha = initAlpha;
            if (enable) canvasGroup.gameObject.SetActive(true);
            yield return new WaitForSeconds(_canvasTransitionWaitForSeconds);
            canvasGroup.DOFade(alpha, 0.3f);
            yield return new WaitForSeconds(_canvasTransitionWaitForSeconds);
            canvasGroup.gameObject.SetActive(enable);
            canvasGroup.interactable = interactable;
        }
    } // END CLASS
}