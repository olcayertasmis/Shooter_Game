using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Manager;
using UnityEngine;
using Logger = _GameFolder.Scripts.Services.Logger;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class Player : BaseCharacter
    {
        [SerializeField] private Logger playerLogger;

        [field: Header("Components")]
        private Rigidbody _rb;

        [Header("Scripts")]
        private PlayerMovement _playerMovement;
        public PlayerInputs PlayerInputs { get; private set; }

        [field: Header("Data")]
        public PlayerData PlayerData { get; private set; }


        protected override void Awake()
        {
            base.Awake();

            PlayerData = Managers.Instance.DataManager.PlayerData;

            _rb = GetComponentInChildren<Rigidbody>();

            PlayerInputs = new PlayerInputs();
            _playerMovement = new PlayerMovement();
        }

        private void Start()
        {
            SetCharacterStats(PlayerData.PlayerMaxHealth, PlayerData.PlayerMovementSpeed, PlayerData.PlayerAttackDelay);

            _playerMovement.OnStart(this);
        }

        private void Update()
        {
        }

        private void FixedUpdate()
        {
            Move();
        }


        public override void Move()
        {
            _playerMovement.Movement();
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