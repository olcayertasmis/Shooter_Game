using System;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class FollowerEnemy : MonoBehaviour
    {
        private Transform _leadEnemy;
        public Enemy LeadEnemyScript { get; private set; }

        private void Start()
        {
            LeadEnemyScript = _leadEnemy.transform.GetComponent<Enemy>();
        }

        public void SetLeadEnemy(Transform leadEnemy)
        {
            _leadEnemy = leadEnemy;
        }
    }
}