using System;
using UnityEngine;

namespace _GameFolder.Scripts.Data
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "New Enemy Data")]
    public class EnemyData : ScriptableObject
    {
        [Header("Enemy Stats")]
        [SerializeField] private float rotationSpeed;

        [Header("Simple Enemy Stats")]
        [SerializeField] private int simpleEnemyMaxHealth;
        [SerializeField] private float simpleEnemyMovementSpeed;
        [SerializeField] private float simpleEnemyMinMoveTime, simpleEnemyMaxMoveTime;

        [Header("Bomber Enemy Stats")]
        [SerializeField] private int bomberEnemyMaxHealth;
        [SerializeField] private float bomberEnemyMovementSpeed;
        [SerializeField] private float bomberEnemyMinMoveTime, bomberEnemyMaxMoveTime;


        #region Enemy Stats Getters

        public float RotationSpeed => rotationSpeed;

        #region Simple Enemy Stats Getters

        public int SimpleEnemyMaxHealth => simpleEnemyMaxHealth;
        public float SimpleEnemyMovementSpeed => simpleEnemyMovementSpeed;
        public float SimpleEnemyMinMoveTime => simpleEnemyMinMoveTime;
        public float SimpleEnemyMaxMoveTime => simpleEnemyMaxMoveTime;

        #endregion

        #region Bomber Enemy Stats Getters

        public int BomberEnemyMaxHealth => bomberEnemyMaxHealth;
        public float BomberEnemyMovementSpeed => bomberEnemyMovementSpeed;
        public float BomberEnemyMinMoveTime => bomberEnemyMinMoveTime;
        public float BomberEnemyMaxMoveTime => bomberEnemyMaxMoveTime;

        #endregion

        #endregion
    } // END CLASS
}