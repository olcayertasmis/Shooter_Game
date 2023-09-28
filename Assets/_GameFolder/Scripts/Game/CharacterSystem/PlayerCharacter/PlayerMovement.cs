using JetBrains.Annotations;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    [System.Serializable]
    public class PlayerMovement
    {
        private Rigidbody _rb;

        private Player _playerScript;

        private Vector3 movementDirection;

        public void OnStart(Player playerScript)
        {
            _playerScript = playerScript;

            _rb = playerScript.GetComponent<Rigidbody>();
        }

        public void OnUpdate()
        {
            movementDirection = _playerScript.transform.right * _playerScript.PlayerInputs.horizontal;
            movementDirection.Normalize();
        }
    }
}