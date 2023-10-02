using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerInputs
    {
        [field: Header("Crosshair Movement Input")]
        public Vector2 CrosshairInput { get; private set; }

        [field: Header("Player Movement Input")]
        public float HorizontalMovementInput { get; private set; }

        [Header("Bool")]
        private bool isFiring;

        public PlayerInputs()
        {
            var playerInput = new PlayerInput();

            playerInput.PlayerActions.CrosshairMove.performed += ctx => CrosshairInput = ctx.ReadValue<Vector2>();
            playerInput.PlayerActions.HorizontalMove.performed += ctx => HorizontalMovementInput = ctx.ReadValue<Vector2>().x;

            playerInput.PlayerActions.Fire.started += ctx => OnFireStarted();
            playerInput.PlayerActions.Fire.canceled += ctx => OnFireCanceled();

            playerInput.Enable();
        }

        private void OnFireStarted()
        {
            isFiring = true;
        }

        private void OnFireCanceled()
        {
            isFiring = false;
        }

        public bool GetFireInput()
        {
            return isFiring;
        }
    } // END CLASS
}