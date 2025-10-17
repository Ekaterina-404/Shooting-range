using UnityEngine;

namespace ShootingRange
{
    public class FallEffectTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effectFallingPrefab;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target"))
            {
                CreateParticle(collision);
                var cube = collision.gameObject;
                Destroy(cube);
            }

            if (collision.gameObject.CompareTag("Bullet"))
            {
                CreateParticle(collision);
                var bullet = collision.gameObject;
                Destroy(bullet);
            }
        }

        private void CreateParticle(Collision collision)
        {
            Vector3 position = collision.contacts[0].point;
            Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(_effectFallingPrefab, position, rotation);
        }
    }
}