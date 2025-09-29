using UnityEngine;

namespace ShootingRange
{
    public class ObjectCollision : MonoBehaviour
    {
        [SerializeField] private GameFinishTrigger _gameFinishTrigger;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                _gameFinishTrigger.DecreaseTargetsCount();
                Destroy(gameObject);
            }
        }
    }
}