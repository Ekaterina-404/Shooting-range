using UnityEngine;

namespace ShootingRange
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Material _material;
        [SerializeField] private Vector3 _scale;

        private void OnCollisionEnter(Collision cube)
        {
            if (cube.gameObject.CompareTag("Respawn"))
            {
            }
        }

        public void Fire(Vector3 direction)
        {
            _rigidbody.AddForce(direction);
        }

        public void SetGravity(bool gravityEnabled)
        {
            _rigidbody.useGravity = gravityEnabled;
        }

        public void SetPosition(Vector3 targetPosition)
        {
            transform.position = targetPosition;
        }
    }
}