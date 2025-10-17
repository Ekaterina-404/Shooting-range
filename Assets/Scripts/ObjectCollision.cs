using UnityEngine;

namespace ShootingRange
{
    public class ObjectCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Finish"))
            {
                Destroy(gameObject);
            }
        }
    }
}