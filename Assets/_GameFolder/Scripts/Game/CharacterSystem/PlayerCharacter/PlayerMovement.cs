using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    [System.Serializable]
    public class PlayerMovement
    {
        private Player _playerScript;

        private Rigidbody _rb;

        private Vector3 movementDirection, movementAmount;

        public void OnStart(Player playerScript)
        {
            _playerScript = playerScript;

            _rb = playerScript.transform.GetComponentInChildren<Rigidbody>();
        }

        public void Movement()
        {
            movementDirection = new Vector3(_playerScript.PlayerInputs.HorizontalMovementInput, 0, 0).normalized;

            movementAmount = _playerScript.PlayerData.PlayerMovementSpeed * movementDirection;

            _rb.velocity = movementAmount;
        }
    } // END CLASS
}