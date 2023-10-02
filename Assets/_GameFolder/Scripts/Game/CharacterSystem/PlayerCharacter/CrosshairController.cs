using System;
using _GameFolder.Scripts.Game.ScreenSystem;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class CrosshairController : MonoBehaviour
    {
        [Header("Action")]
        public Action<Transform> onFireAction;

        [Header("Data Variable")]
        private float _crosshairSpeed;
        private float _fireRange;
        private LayerMask _layerMask;

        [Header("Components")]
        private Camera _cam;
        private RectTransform _crosshair;

        [Header("Other Scripts")]
        private PlayerInputs _playerInputs;
        private CanvasBounds canvasBounds;

        private void Awake()
        {
            var playerData = Managers.Instance.DataManager.PlayerData;

            _crosshairSpeed = playerData.CrosshairSpeed;
            _fireRange = playerData.FireRange;
            _layerMask = playerData.CrosshairLayerMask;

            _cam = Camera.main;

            _crosshair = transform.GetChild(0).GetComponent<RectTransform>();

            canvasBounds = GetComponent<CanvasBounds>();
        }

        private void Start()
        {
            _playerInputs = new PlayerInputs();
        }

        private void Update()
        {
            MoveCrosshair();
            CheckForEnemyAndShoot();
        }

        private void MoveCrosshair()
        {
            var movementInput = _playerInputs.CrosshairInput;

            var movement = new Vector2(movementInput.x, movementInput.y);
            var newPosition = _crosshair.anchoredPosition + movement * (_crosshairSpeed * Time.deltaTime);

            newPosition.x = Mathf.Clamp(newPosition.x, canvasBounds.GetMinBounds().x, canvasBounds.GetMaxBounds().x);
            newPosition.y = Mathf.Clamp(newPosition.y, canvasBounds.GetMinBounds().y, canvasBounds.GetMaxBounds().y);

            _crosshair.anchoredPosition = newPosition;
        }

        private void CheckForEnemyAndShoot()
        {
            var crosshairWorldPos = _cam.ScreenPointToRay(_crosshair.position);

            RaycastHit hit;

            if (Physics.Raycast(_cam.transform.position, crosshairWorldPos.direction, out hit, _fireRange * 100, _layerMask))
            {
                if (_playerInputs.GetFireInput())
                {
                    onFireAction?.Invoke(hit.transform);
                }
            }
        }

        /*private void OnDrawGizmos()
        {
            var crosshairWorldPos = _cam.ScreenPointToRay(_crosshair.position);

            Debug.DrawRay(_cam.transform.position, crosshairWorldPos.direction * 100f);
        }*/
    } // END CLASS
}