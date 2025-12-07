using System;

using Unity.VisualScripting;

using UnityEngine;

namespace ShootingRange
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Vector3 _scale;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private TrailRenderer _trailRenderer;
        [SerializeField] private ParticleSystem _piecesEffect;

        [SerializeField] private float _force = 2000f;

        private Vector3 _direction;
        private Vector3 _rotation;
        private Transform _target;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                _piecesEffect.gameObject.SetActive(true);
                _piecesEffect.Play();
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
        }

        public void Fire(Camera camera)
        {
            _rigidbody.freezeRotation = false;
            _direction = GetDirection(camera.transform);
            _rigidbody.AddForce(_direction);
            Destroy(gameObject, 2f);
        }

        private Vector3 GetDirection(Transform mainPoint)
        {
            var distanceX = transform.position.x - mainPoint.transform.position.x;
            Quaternion rotation = Quaternion.Euler(0, distanceX * 20f, 0);
            transform.rotation = rotation;
            var direction = transform.forward * _force;
            return direction;
        }

        public void EnableGravity(bool gravityEnabled)
        {
            _rigidbody.useGravity = gravityEnabled;
        }

        public void EnableTrail(bool trailEnabled)
        {
            _trailRenderer.enabled = trailEnabled;
        }

        public void SetPosition(Vector3 targetPosition)
        {
            transform.position = targetPosition;
        }

        public void SetMaterial(Material material)
        {
            _meshRenderer.material = material;
        }
    }
}