using UnityEngine;

namespace ShootingRange
{
    public class ObjectCollision : MonoBehaviour
    {
        [SerializeField] private GameFinishTrigger _gameFinishTrigger;

        private void OnCollisionEnter(Collision collision) // Выполняется при столкновении объекта с другим объектом 
        {
            if (collision.gameObject.CompareTag("Respawn")) // Проверка, столкновения этого объект с определенным объектом
            {
                _gameFinishTrigger.DecreaseTargetsCount();
                Destroy(gameObject);
            }

            /*if (collision.gameObject.CompareTag("Environment")) 
            {
                var cube = GameObject.Find("Target");
                
                Destroy(cube);
            }
            */
        }
    }
}