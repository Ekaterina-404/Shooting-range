using UnityEngine;

namespace ShootingRange
{
    public class ObjectCollision : MonoBehaviour
    {
        [SerializeField] private GameFinishTrigger _gameFinishTrigger;

        private Rigidbody _rigidbodyCube;

        private void OnCollisionEnter(Collision collision) 
        {
            if (collision.gameObject.CompareTag("Finish")) 
            {
                _gameFinishTrigger.DecreaseTargetsCount();
                Destroy(gameObject);
            }

            if (collision.gameObject.CompareTag("Bullet")) 
            {
                _rigidbodyCube = GetComponent<Rigidbody>();
                _rigidbodyCube.mass = 1;
            }
        }
    }
}