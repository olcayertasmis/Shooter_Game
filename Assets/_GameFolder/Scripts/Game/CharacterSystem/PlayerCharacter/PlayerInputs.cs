using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerInputs
    {
        private Vector2 _vector2Input;

        public float horizontal;

        public PlayerInputs()
        {
            var playerInput = new PlayerInput();

            playerInput.PlayerActions.Movement.performed += input => _vector2Input = input.ReadValue<Vector2>();
            playerInput.Enable();
        }

        public void OnUpdate()
        {
            horizontal = _vector2Input.x;
        }
    }
}