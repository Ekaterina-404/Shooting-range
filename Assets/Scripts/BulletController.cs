using UnityEngine;
using UnityEngine.Assertions;

namespace ShootingRange
{
    public class BulletController : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float _force = 3000f;
        [SerializeField] private float _distance = 5f;

        [Header("References")]
        [SerializeField] private Bullet _bulletPrefab;

        private Bullet _currentBullet;
        private Vector3 _direction;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
            Assert.IsNotNull(_camera);
            _direction = _camera.transform.forward * _force;

            CreateSphere();
        }

        private void Update()
        {
            FixItToMouse(_currentBullet);

            if (Input.GetMouseButtonUp(0))
            {
                _currentBullet.SetGravity(true);
                _currentBullet.Fire(_direction);
                CreateSphere();
            }
        }

        private void CreateSphere()
        {
            _currentBullet = Instantiate(_bulletPrefab);
            _currentBullet.SetGravity(false);
        }

        private void FixItToMouse(Bullet bullet)
        {
            var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            var mousePositionInTheWorld = _camera.ScreenToWorldPoint(mousePosition);
            bullet.SetPosition(mousePositionInTheWorld);
        }
    }
}