using System.Collections;
using _GameFolder.Scripts.Game.CharacterSystem.EnemyCharacter;
using UnityEngine;

namespace _GameFolder.Scripts.Game.ScreenSystem
{
    public class InCameraDetector : MonoBehaviour
    {
        [Header("Camera Components")]
        private Plane[] _cameraFrustum;
        private Camera _cam;
        private Collider _collider;

        [Header("Enemy")]
        private Enemy _enemy;
        private bool _isItInside;
        private bool _didChange = true;

        private void Start()
        {
            StartCoroutine(SetAfterStart());
        }

        private void Update()
        {
            if (_cam != null) SetScreenBoundaries();
            if (!_isItInside && !_didChange) StartCoroutine(EnemySetFeatures());
        }

        private void SetScreenBoundaries()
        {
            var bounds = _collider.bounds;

            _cameraFrustum = GeometryUtility.CalculateFrustumPlanes(_cam);
            _isItInside = GeometryUtility.TestPlanesAABB(_cameraFrustum, bounds);
        }

        private IEnumerator SetAfterStart()
        {
            yield return new WaitForSeconds(3f);
            _enemy = GetComponent<Enemy>();
            _cam = Camera.main;
            _collider = GetComponentInChildren<Collider>();
            _didChange = false;
        }

        private IEnumerator EnemySetFeatures()
        {
            _didChange = true;
            _enemy.SetFeatures();
            yield return new WaitForSeconds(3f);
            _didChange = false;
        }
    }
}