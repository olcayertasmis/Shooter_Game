using System;
using _GameFolder.Scripts.Data;
using _GameFolder.Scripts.Interface;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem
{
    public class BaseCharacter : MonoBehaviour, IMovable, IDamageable
    {
        protected int Health;
        protected float Speed;
        protected GameData GameData;

        protected virtual void Awake()
        {
            GameData = Managers.Instance.DataManager.GameData;
        }

        protected void SetCharacterStats(int health, float speed)
        {
            Health = health;
            Speed = speed;
        }

        public virtual void Move(float direction)
        {
            throw new System.NotImplementedException();
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Die();
            }
        }

        protected virtual void Die()
        {
        }
    }
}