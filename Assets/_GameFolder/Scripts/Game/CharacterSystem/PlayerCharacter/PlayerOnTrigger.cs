using _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.transform.parent.CompareTag("Enemy")) Attack(other);
            Debug.Log(other.gameObject.name);
        }

        private void Attack(Collider other)
        {
            other.gameObject.GetComponentInParent<Enemy>().TakeDamage(1);
        }
    }
}