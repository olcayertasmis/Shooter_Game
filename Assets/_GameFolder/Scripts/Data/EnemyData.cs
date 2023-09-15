using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "New Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Enemy Stats")]
        [SerializeField] private float rotationSpeed;
        [Space]
        [Space]
        [Space]
        [Header("Simple Enemy Stats")]
        [SerializeField] private int simpleEnemyMaxHealth;
        [SerializeField] private float simpleEnemyMovementSpeed;
        [SerializeField] private float simpleEnemyMinMoveTime, simpleEnemyMaxMoveTime;
        [Header("Simple Enemy Attack Stats")]
        [SerializeField] private float simpleEnemyAttackDelay;
        [SerializeField] private GameObject simpleEnemyBullet;
        [SerializeField] private int simpleEnemyDamageValue;
        [Space]
        [Space]
        [Space]
        [Header("Bomber Enemy Stats")]
        [SerializeField] private int bomberEnemyMaxHealth;
        [SerializeField] private float bomberEnemyMovementSpeed;
        [SerializeField] private float bomberEnemyMinMoveTime, bomberEnemyMaxMoveTime;
        [Header("Bomber Enemy Attack Stats")]
        [SerializeField] private float bomberEnemyAttackDelay;
        [SerializeField] private GameObject bomberEnemyBullet;
        [SerializeField] private int bomberEnemyDamageValue;


        #region Enemy Stats Getters

        public float RotationSpeed => rotationSpeed;

        #region Simple Enemy Stats Getters

        public int SimpleEnemyMaxHealth => simpleEnemyMaxHealth;
        public float SimpleEnemyMovementSpeed => simpleEnemyMovementSpeed;
        public float SimpleEnemyMinMoveTime => simpleEnemyMinMoveTime;
        public float SimpleEnemyMaxMoveTime => simpleEnemyMaxMoveTime;
        public float SimpleEnemyAttackDelay => simpleEnemyAttackDelay;
        public GameObject SimpleEnemyBullet => simpleEnemyBullet;
        public int SimpleEnemyDamageValue => simpleEnemyDamageValue;

        #endregion

        #region Bomber Enemy Stats Getters

        public int BomberEnemyMaxHealth => bomberEnemyMaxHealth;
        public float BomberEnemyMovementSpeed => bomberEnemyMovementSpeed;
        public float BomberEnemyMinMoveTime => bomberEnemyMinMoveTime;
        public float BomberEnemyMaxMoveTime => bomberEnemyMaxMoveTime;
        public float BomberEnemyAttackDelay => bomberEnemyAttackDelay;
        public GameObject BomberEnemyBullet => bomberEnemyBullet;
        public int BomberEnemyDamageValue => bomberEnemyDamageValue;

        #endregion

        #endregion
    } // END CLASS
}