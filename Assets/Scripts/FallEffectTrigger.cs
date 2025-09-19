using UnityEngine;

namespace ShootingRange
{
    public class FallEffectTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _effectFallingPrefab;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Target")
            {
                СreateParticle(collision);
                var cube = GameObject.Find("Target");
                Destroy(cube);
            }

            if (collision.gameObject.tag == "Bullet")
            {
                СreateParticle(collision);
                var bullet = GameObject.Find("Bullet");
                Destroy(bullet);
            }
        }

        private void СreateParticle(Collision collision)
        {
            Vector3 position = collision.contacts[0].point;
            Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(_effectFallingPrefab, position, rotation);
        }
    }
}