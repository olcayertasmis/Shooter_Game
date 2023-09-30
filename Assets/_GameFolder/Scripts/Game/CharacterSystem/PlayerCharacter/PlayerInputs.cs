using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerInputs
    {
        public Vector2 CrosshairInput { get; private set; }
        public float HorizontalMovementInput { get; private set; }

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