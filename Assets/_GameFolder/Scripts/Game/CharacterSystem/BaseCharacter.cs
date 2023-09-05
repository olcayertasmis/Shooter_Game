using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Interface;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem
{
    public class BaseCharacter : MonoBehaviour, IMovable, IDamageable
    {
        [Header("Stats")]
        private int _health;
        private float _speed;

        [Header("Data")]
        protected GameData GameData;
        
        

        protected virtual void Awake()
        {
            GameData = Managers.Instance.DataManager.GameData;
        }

        protected void SetCharacterStats(int health, float speed)
        {
            _health = health;
            _speed = speed;
        }

        public virtual void Move(float direction)
        {
            //throw new System.NotImplementedException();
        }

        public virtual void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
        }
    } // END CLASS
}