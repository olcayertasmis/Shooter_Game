using _GameFolder.Scripts.Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _GameFolder.Scripts.Menu
{
    public class BackgroundClickDetector : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private CanvasChanger canvasChanger;

        public void OnPointerClick(PointerEventData eventData)
        {
            foreach (var canvasGroup in Managers.Instance.MenuUIManager.AllCanvasGroups)
            {
                if (!canvasGroup.gameObject.activeSelf) return;

                canvasChanger.HideCanvas(canvasGroup); // Main Menu Panel hariç hepsini kapatma işlemi

                canvasChanger.ShowMenuPanel(transform.GetComponent<CanvasGroup>());
            }
        }
    } // END CLASS
}