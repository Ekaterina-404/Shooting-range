using System.Timers;

using UnityEngine;
using UnityEngine.Assertions;

namespace ShootingRange
{
    public class BulletController : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float _distance = 6f;

        [Header("References")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private MaterialProvider _materialProvider;
        [SerializeField] private AmmoTracker _ammoTracker;
        [SerializeField] private GameObject _gameOverUI;

        private Camera _camera;
        private Bullet _currentBullet;
        private Transform _target;

        private void Start()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);
            CreateSphere();
        }

        private void Update()
        {
            if (!_gameOverUI.activeInHierarchy)
            {
                FixItToMouse(_currentBullet);
                _currentBullet.gameObject.SetActive(true);

                if (Input.GetMouseButtonUp(0) && _ammoTracker.AmmoBullet > 0)
                {
                    _currentBullet.EnableGravity(true);
                    _currentBullet.EnableTrail(true);
                    _currentBullet.Fire(_camera);
                    CreateSphere();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _ammoTracker.SpendAmmoBullet();
        }

        private void CreateSphere()
        {
            _currentBullet = Instantiate(_bulletPrefab);
            _currentBullet.gameObject.SetActive(false);
            SetRandomMaterialBullet(_currentBullet);
        }

        private void SetRandomMaterialBullet(Bullet bullet)
        {
            var material = _materialProvider.GetRandomMaterial();
            bullet.SetMaterial(material);
        }

        private void FixItToMouse(Bullet bullet)
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            var mousePositionInTheWorld = _camera.ScreenToWorldPoint(mousePosition);
            bullet.SetPosition(mousePositionInTheWorld);
        }
    }
}