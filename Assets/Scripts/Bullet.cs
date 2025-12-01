using System;

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
        private bool _canPlayParticles = true;

        private Vector3 _direction;
        private Vector3 _rotation;
        private Transform _target;
        private float _vInput;
        private float _hInput;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target") && _canPlayParticles)
            {
                _piecesEffect.Play();
                _canPlayParticles = false;
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
        }

        public void Fire(Camera camera)
            
        {
            _rigidbody.freezeRotation = false;
            _hInput = Input.GetAxis("Mouse X");
            _vInput = Input.GetAxis("Mouse Y");
            transform.Rotate(_hInput, 0, _vInput);
            var xPosition = transform.position.x;
            _direction = camera.transform.forward * _force;

            if (-3f > xPosition)
            {
                _direction += Vector3.left * 800f;
            }
            else if (-3f <= xPosition && xPosition <= -2f)
            {
                _direction += Vector3.left * 300f;
            }
            else if (0.42f <= xPosition && xPosition <= 1.6f)
            {
                _direction += Vector3.right * 300f;
            }
            else if (1.6f < xPosition)
            {
                _direction += Vector3.right * 800f;
            }

            _rigidbody.AddForce(_direction);

            Destroy(gameObject, 2f);
        }

        public void SetGravity(bool gravityEnabled)
        {
            _rigidbody.useGravity = gravityEnabled;
        }

        public void SetTrail(bool trailEnabled)
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