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
        protected float _speed;

        [Header("Data")]
        protected GameData gameData;


        protected virtual void Awake()
        {
            gameData = Managers.Instance.DataManager.GameData;
        }

        protected void SetCharacterStats(int health, float speed)
        {
            _health = health;
            _speed = speed;
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