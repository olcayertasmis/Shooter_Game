using System;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class CrosshairController : MonoBehaviour
    {
        public Action onFireAction;

        private float crosshairSpeed;
        private float fireRange;
        private LayerMask layerMask;

        private Camera cam;

        private PlayerInputs playerInputs;

        private void Awake()
        {
            var playerData = Managers.Instance.DataManager.PlayerData;

            crosshairSpeed = playerData.CrosshairSpeed;
            fireRange = playerData.FireRange;
            layerMask = playerData.CrosshairLayerMask;

            cam = Camera.main;
        }

        private void Start()
        {
            playerInputs = new PlayerInputs();
        }

        private void Update()
        {
            MoveCrosshair();
            CheckForEnemyAndShoot();

            //Debug.Log(playerInputs.GetFireInput());
        }

        private void MoveCrosshair()
        {
            var movementInput = playerInputs.CrosshairInput;

            var movement = new Vector3(movementInput.x, movementInput.y, 0f);

            transform.Translate(movement * (crosshairSpeed * Time.deltaTime));
        }

        private void CheckForEnemyAndShoot()
        {
            var ray = cam.ScreenPointToRay(transform.position);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, fireRange, layerMask))
            {
                Debug.Log("1");
                if (playerInputs.GetFireInput())
                {
                    onFireAction?.Invoke();
                    Debug.Log("2");
                }
            }
        }
    } // END CLASS
}