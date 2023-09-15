using UnityEngine;
using Logger = _GameFolder.Scripts.Services.Logger;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class Player : BaseCharacter
    {
        [SerializeField] private Logger playerLogger;

        private void Start()
        {
            SetCharacterStats(gameData.PlayerMaxHealth, gameData.PlayerMovementSpeed, gameData.PlayerAttackDelay);
        }


        public override void Move()
        {
        }

        public override void Die()
        {
        }

        #region Plugin

        private void Log(object message)
        {
            if (playerLogger) playerLogger.Log(message, this);
        }

        #endregion
    } // END CLASS
}