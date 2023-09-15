using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class FollowerEnemy : MonoBehaviour
    {
        public Enemy LeadEnemyScript { get; private set; }

        public void SetLeadEnemy(Transform leadEnemy)
        {
            LeadEnemyScript = leadEnemy.transform.GetComponent<Enemy>();
        }
    } // END CLASS
}