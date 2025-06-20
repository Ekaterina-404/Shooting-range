using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    private GameObject _objectToRemove;
    private void OnCollisionEnter(Collision collision)     // Выполняется при столкновении объекта с другим объектом 
    {
        if (collision.gameObject.CompareTag("Respawn")) //другой объект
        // Проверяем, столкнулся ли наш объект с определенным объектом
        //if (cube.gameObject == _objectToRemove)
        {
            // Удаляем объект из сцены
            Destroy(gameObject);
        }
    }
}
