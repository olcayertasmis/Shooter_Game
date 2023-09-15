using _GameFolder.Scripts.Enums;
using _GameFolder.Scripts.Game.CharacterSystem.PlayerCharacter;
using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class EnemyOnTrigger : MonoBehaviour
    {
        [SerializeField] private EnemyEnum.EnemyType enemyType;

        private int _damageValue;

        private void Awake()
        {
            _damageValue = enemyType switch
            {
                EnemyEnum.EnemyType.SimpleEnemy => Managers.Instance.DataManager.EnemyData.SimpleEnemyDamageValue,
                EnemyEnum.EnemyType.BomberEnemy => Managers.Instance.DataManager.EnemyData.BomberEnemyDamageValue,
            };
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.transform.parent.CompareTag("Player"))
            {
                ToDamage(other);
                Debug.Log(other.gameObject.name);
            }

            if (enemyType == EnemyEnum.EnemyType.BomberEnemy && other.gameObject.CompareTag("Plane"))
            {
                //patlama efekti
            }
        }

        private void ToDamage(Component other)
        {
            other.gameObject.GetComponentInParent<Player>().TakeDamage(_damageValue);
        }
    }
}