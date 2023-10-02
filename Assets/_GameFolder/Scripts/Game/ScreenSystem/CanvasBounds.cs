using UnityEngine;

namespace _GameFolder.Scripts.Game.ScreenSystem
{
    public class CanvasBounds : MonoBehaviour
    {
        [Header("Components")]
        private RectTransform _canvasRect;

        [Header("Bounds")]
        private Vector2 _minBounds, _maxBounds;

        private void Awake()
        {
            _canvasRect = GetComponent<RectTransform>();

            RecalculateBounds();
        }

        private void RecalculateBounds()
        {
            var rect = _canvasRect.rect;

            _minBounds = rect.min;
            _maxBounds = rect.max;
        }

        public Vector2 GetMinBounds()
        {
            return _minBounds;
        }

        public Vector2 GetMaxBounds()
        {
            return _maxBounds;
        }
    }
}