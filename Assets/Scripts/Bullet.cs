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

        private bool _canPlayParticles = true;

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

        public void Fire(Vector3 direction)
        {
            _rigidbody.freezeRotation = false;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            _transform.rotation = rotation;

            _rigidbody.AddForce(direction);
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