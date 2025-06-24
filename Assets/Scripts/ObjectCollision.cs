using UnityEngine;

namespace ShootingRange
{
    public class ObjectCollision : MonoBehaviour
    {
        private GameObject _objectToRemove;

        private void OnCollisionEnter(Collision collision) // Выполняется при столкновении объекта с другим объектом 
        {
            if (collision.gameObject.CompareTag("Respawn")) // Проверка, столкновения этого объект с определенным объектом
            {
                Destroy(gameObject);
            }
        }
    }
}