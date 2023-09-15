using _GameFolder.Scripts.Manager;
using UnityEngine;

namespace _GameFolder.Scripts.Game.ScreenSystem
{
    public class ScreenBoundaries : MonoBehaviour
    {
        Plane[] cameraFrustum;

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
            }
        }
    }
}