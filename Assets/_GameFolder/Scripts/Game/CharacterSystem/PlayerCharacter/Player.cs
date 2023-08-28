using System;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class Player : BaseCharacter
    {
        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            SetCharacterStats(GameData.PlayerMaxHealth, GameData.PlayerMovementSpeed);
        }

        public override void Move(float direction)
        {
            base.Move(direction);
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage(damage);
        }

        protected override void Die()
        {
            base.Die();
        }
    }
}