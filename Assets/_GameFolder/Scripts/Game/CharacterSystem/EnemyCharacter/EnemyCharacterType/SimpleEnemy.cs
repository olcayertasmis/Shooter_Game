using _GameFolder.Scripts.Enums;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter.EnemyCharacterType
{
    public class SimpleEnemy : Enemy
    {
        private GameObject _bulletPrefab;

        protected override void Start()
        {
            enemyType = EnemyEnum.EnemyType.BomberEnemy;
            base.Start();
            _bulletPrefab = enemyData.SimpleEnemyBullet;
        }

        protected override void Update()
        {
            base.Update();
            if (canAttackProcess) AttackProcess();
        }

        protected override void AttackProcess()
        {
            base.AttackProcess();
            var bullet = Instantiate(_bulletPrefab, bulletSpawnTransform.position, Quaternion.identity);

            bullet.transform.Translate(playerTransform.position * Time.deltaTime);
        }
    }
}