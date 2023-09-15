using _GameFolder.Scripts.Enums;
using DG.Tweening;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter.EnemyCharacterType
{
    public class BomberEnemy : Enemy
    {
        private GameObject _bulletPrefab;

        protected override void Start()
        {
            enemyType = EnemyEnum.EnemyType.BomberEnemy;
            base.Start();
            _bulletPrefab = enemyData.BomberEnemyBullet;
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

            bullet.transform.DOJump(playerTransform.position, 5f, 0, 3f);
        }
    }
}