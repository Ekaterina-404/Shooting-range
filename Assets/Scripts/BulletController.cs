using UnityEngine;
using UnityEngine.Assertions;

namespace ShootingRange
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;

        [Header("Values")]
        [SerializeField] private float _force = 3000f;
        [SerializeField] private float _distance = 6f;
        // [SerializeField] private int _bulletAmmo = 5;

        [Header("References")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private ColorProvider _colorProvider;
        [SerializeField] private AmmoTracker _ammoTracker;

        private Camera _camera;
        private Bullet _currentBullet;
        private Vector3 _direction;
        //private int _bulletsFired;

        private void Start()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);
            _direction = _camera.transform.forward * _force;
            CreateSphere();
        }

        private void Update()
        {
            if (!_gameOverUI.activeInHierarchy)
            {
                FixItToMouse(_currentBullet);

                if (Input.GetMouseButtonUp(0) && _ammoTracker.AmmoBullet > 0)
                {
                    _currentBullet.SetGravity(true);
                    _currentBullet.SetTrail(true);
                    _currentBullet.SetRotation(true);
                    _currentBullet.Fire(_direction);
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
            _currentBullet.SetGravity(false);
            SetRandomMaterial(_currentBullet);
        }

        private void SetRandomMaterial(Bullet bullet)
        {
            var material = _colorProvider.GetRandomMaterial();
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