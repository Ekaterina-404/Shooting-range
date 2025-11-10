using System;

using UnityEngine;

namespace ShootingRange
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private GameFinishTrigger _gameFinishTrigger;

        private int _countCube;
        private Rigidbody _rigidbodyCube;

        private void OnTriggerEnter(Collider colliderObject)
        {
            if (colliderObject.gameObject.CompareTag("Target"))
            {
                GameObject cube = colliderObject.gameObject;
                _rigidbodyCube = cube.GetComponent<Rigidbody>();
                _rigidbodyCube.mass = 1;
                _countCube += 1;

                if (_countCube == 6)
                {
                    Debug.Log("Кубы на месте!");
                }
            }
        }

        private void OnTriggerExit(Collider colliderObject)
        {
            if (colliderObject.gameObject.CompareTag("Target"))
            {
                _gameFinishTrigger.DecreaseTargetsCount();
            }
        }
    }
}