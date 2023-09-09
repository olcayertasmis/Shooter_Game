using System;
using _GameFolder.Scripts.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _GameFolder.Scripts.Game.ScreenSystem
{
    public class ScreenBoundaries : MonoBehaviour
    {
        Plane[] cameraFrustum;

        private void Awake()
        {
            SetScreenBoundaries();
        }

        private void Start()
        {
            //Vector3 spawnPosition = new Vector3(Random.Range(0, 2) == 0 ? leftBound : rightBound, 0.25f, Random.Range(25f, 50f));
            Vector3 v3Pos1 = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0, 2), 0f, Random.Range(5f, 50f)));
            print(v3Pos1);
        }

        private void SetScreenBoundaries()
        {
            var managers = Managers.Instance;
            var gameData = managers.DataManager.GameData;
            var enemySpawnerData = managers.DataManager.EnemySpawnerData;

            var cam = Camera.main;


            if (cam == null) return;

            cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
            foreach (var x in cameraFrustum)
            {
                Debug.Log(x);
            }
        }
    }
}