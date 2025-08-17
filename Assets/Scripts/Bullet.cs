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

        [SerializeField] private ParticleSystem _particleSystem;

        private bool _canPlayParticles = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Target" && _canPlayParticles)
            {
                _particleSystem.Play();
                _canPlayParticles = false;
            }
        }

        public void Fire(Vector3 direction)
        {
            _rigidbody.AddForce(direction);
            Destroy(gameObject, 5f);
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