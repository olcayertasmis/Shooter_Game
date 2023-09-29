using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerInputs
    {
        public Vector2 CrosshairInput { get; private set; }
        public float HorizontalMovementInput { get; private set; }

        public PlayerInputs()
        {
            var playerInput = new PlayerInput();

            playerInput.PlayerActions.CrosshairMove.performed += ctx => CrosshairInput = ctx.ReadValue<Vector2>();
            playerInput.PlayerActions.HorizontalMove.performed += ctx => HorizontalMovementInput = ctx.ReadValue<Vector2>().x;

            playerInput.Enable();
        }
    } // END CLASS
}