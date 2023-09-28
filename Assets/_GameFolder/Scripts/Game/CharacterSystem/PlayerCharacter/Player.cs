using System;
using UnityEngine;
using Logger = _GameFolder.Scripts.Services.Logger;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class Player : BaseCharacter
    {
        [SerializeField] private Logger playerLogger;

        private PlayerInputs _playerInputs;
        private PlayerMovement _playerMovement;

        private Rigidbody _rb;

        #region Getters

        public PlayerInputs PlayerInputs => _playerInputs;

        #endregion

        protected override void Awake()
        {
            base.Awake();

            _rb = GetComponent<Rigidbody>();

            _playerInputs = new PlayerInputs();
            _playerMovement = new PlayerMovement();
        }

        private void Start()
        {
            SetCharacterStats(playerData.PlayerMaxHealth, playerData.PlayerMovementSpeed, playerData.PlayerAttackDelay);

            _playerMovement.OnStart(this);
        }

        private void Update()
        {
            _playerInputs.OnUpdate();
            _playerMovement.OnUpdate();
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