using System.Collections;
using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace _GameFolder.Scripts.Menu
{
    public class BackgroundTransition : MonoBehaviour
    {
        [Header("Managers")]
        private Managers _managers;
        private MenuData _menuData;


        [Header("Values")]
        private Image _backgroundImage;
        private float _transitionDuration;
        private int _currentIndex;

        private Coroutine _autoTransitionCoroutine;

        private void Awake()
        {
            _managers = Managers.Instance;
            _menuData = _managers.DataManager.MenuData;

            _backgroundImage = _managers.MenuUIManager.BackgroundImage;
            _transitionDuration = _menuData.TransitionDuration;
        }

        private void Start()
        {
            _backgroundImage.sprite = _menuData.BackgroundSprites[0];
            _currentIndex = 0;

            _autoTransitionCoroutine = StartCoroutine(AutoTransition());
        }

        #region Transition

        private IEnumerator AutoTransition()
        {
            while (true)
            {
                yield return new WaitForSeconds(_menuData.AutoTransitionInterval);

                int nextIndex = (_currentIndex + 1) % _menuData.BackgroundSprites.Count;
                yield return StartCoroutine(TransitionToNextImage(nextIndex));
            }
        }

        private IEnumerator TransitionToNextImage(int nextIndex)
        {
            float elapsedTime = 0.0f;
            Sprite currentSprite = _backgroundImage.sprite;
            Sprite nextSprite = _menuData.BackgroundSprites[nextIndex];

            while (elapsedTime < _transitionDuration)
            {
                float t = elapsedTime / _transitionDuration;
                SetAlpha(_backgroundImage, 1.0f - t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SetAlpha(_backgroundImage, 0.0f);
            _backgroundImage.sprite = nextSprite;
            _currentIndex = nextIndex;

            while (elapsedTime < _transitionDuration * 2)
            {
                float t = (elapsedTime - _transitionDuration) / _transitionDuration;
                SetAlpha(_backgroundImage, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            SetAlpha(_backgroundImage, 1.0f);
        }

        private static void SetAlpha(Image image, float alpha)
        {
            Color color = image.color;
            color.a = alpha;
            image.color = color;
        }

        #endregion
    } // END CLASS
}