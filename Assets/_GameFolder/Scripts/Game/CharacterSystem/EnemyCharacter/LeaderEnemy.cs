using System.Collections.Generic;
using _GameFolder.Scripts.Enums;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter
{
    public class LeaderEnemy : MonoBehaviour
    {
        public List<Enemy> followerEnemies = new List<Enemy>();

        public void SetNewLeaderEnemy()
        {
            if (followerEnemies.Count == 0) return;
            var random = Random.Range(0, followerEnemies.Count);

            var newLeaderEnemy = followerEnemies[random];

            followerEnemies.RemoveAt(random);

            newLeaderEnemy.isLeaderEnemy = true;
            newLeaderEnemy.SetEnemySpawnerType(EnemyEnum.SpawnerType.Solo);
            Destroy(newLeaderEnemy.transform.GetComponent<FollowerEnemy>());

            var newLeaderEnemyScript = newLeaderEnemy.transform.AddComponent<LeaderEnemy>();
            newLeaderEnemy.SetLeaderEnemyScript();


            foreach (var enemy in followerEnemies)
            {
                enemy.transform.GetComponent<FollowerEnemy>().SetLeadEnemy(newLeaderEnemy.transform);
                newLeaderEnemyScript.followerEnemies.Add(enemy);
            }
        }
    } // END CLASS
}