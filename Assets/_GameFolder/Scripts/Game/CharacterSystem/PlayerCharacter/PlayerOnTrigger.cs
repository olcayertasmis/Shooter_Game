using _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter;
using UnityEngine;
using UnityEngine.Assertions;

namespace _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter
{
    public class PlayerOnTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent != null && other.transform.parent.CompareTag("Enemy")) ToDamage(other);

            Debug.Log(other.gameObject.name);
        }

        private static void ToDamage(Component other)
        {
            other.gameObject.GetComponentInParent<Enemy>().TakeDamage(1);
        }
    }
}