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
        
        [Header("References")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private MaterialProvider _materialProvider;
        [SerializeField] private AmmoTracker _ammoTracker;

        private Camera _camera;
        private Bullet _currentBullet;
        private Vector3 _direction;
        private Transform _target;

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
                    _currentBullet.DisableKinematic(false);
                    _currentBullet.SetGravity(true);
                    _currentBullet.SetTrail(true);
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
            _currentBullet.DisableKinematic(false);
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