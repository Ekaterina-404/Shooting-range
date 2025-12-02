using UnityEngine;

namespace ShootingRange
{
    public class FallEffectTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effectFallingPrefab;
        [SerializeField] private GameObject _gameOverUI;

        public void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Target") || collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);

                if (!_gameOverUI.activeInHierarchy)
                {
                    CreateParticle(collision);
                }
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