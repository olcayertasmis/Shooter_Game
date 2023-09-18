using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Interface;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem
{
    public abstract class BaseCharacter : MonoBehaviour, IMovable, IDamageable
    {
        [Header("Stats")]
        private int _health;
        protected float speed;
        protected float attackDelay;

        [Header("Data")]
        protected PlayerData playerData;


        protected virtual void Awake()
        {
            playerData = Managers.Instance.DataManager.PlayerData;
        }

        protected void SetCharacterStats(int health, float speedValue, float attackDelayValue)
        {
            _health = health;
            speed = speedValue;
            attackDelay = attackDelayValue;
        }

        public abstract void Move();

        public virtual void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        public abstract void Die();
    } // END CLASS
}