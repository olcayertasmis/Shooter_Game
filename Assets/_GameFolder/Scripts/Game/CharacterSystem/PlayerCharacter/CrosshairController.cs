using System;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class CrosshairController : MonoBehaviour
    {
        public Action onFireAction;

        private float _crosshairSpeed;
        private float _fireRange;
        private LayerMask _layerMask;

        private Camera _cam;

        private PlayerInputs _playerInputs;

        private RectTransform _crosshair;

        private void Awake()
        {
            var playerData = Managers.Instance.DataManager.PlayerData;

            _crosshairSpeed = playerData.CrosshairSpeed;
            _fireRange = playerData.FireRange;
            _layerMask = playerData.CrosshairLayerMask;

            _cam = Camera.main;

            _crosshair = transform.GetChild(0).GetComponent<RectTransform>();
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

            var movement = new Vector2(movementInput.x, movementInput.y) * (_crosshairSpeed * Time.deltaTime);

            _crosshair.anchoredPosition += movement;
        }

        private void CheckForEnemyAndShoot()
        {
            var ray = _cam.ScreenPointToRay(transform.position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _fireRange, _layerMask))
            {
                if (_playerInputs.GetFireInput())
                {
                    onFireAction?.Invoke();
                }
            }
        }
    } // END CLASS
}