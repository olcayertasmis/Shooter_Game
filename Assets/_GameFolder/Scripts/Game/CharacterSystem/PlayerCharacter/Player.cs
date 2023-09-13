using _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter;
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
            //Move(1f);
        }

        /*public override void Move(float direction)
        {
            base.Move(direction);
        }*/


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy")) Attack(other);
            Log(other.gameObject.name);
        }

        private void Attack(Collider other)
        {
            other.gameObject.GetComponent<Enemy>().TakeDamage(1);
        }

        private void Log(object message)
        {
            if (playerLogger) playerLogger.Log(message, this);
        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }

        public override void Die()
        {
            throw new System.NotImplementedException();
        }
    } // END CLASS
}