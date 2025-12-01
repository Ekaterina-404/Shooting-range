using System;

using UnityEngine;

namespace ShootingRange
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private GameFinishTrigger _gameFinishTrigger;
        [SerializeField] private GameObject _gameArea;

        private int _countCube;
        private Rigidbody _rigidbodyCube;

        private void OnTriggerEnter(Collider colliderObject)
        {
            if (colliderObject.gameObject.CompareTag("Target"))
            {
                GameObject cube = colliderObject.gameObject;
                _rigidbodyCube = colliderObject.gameObject.GetComponent<Rigidbody>();
                _rigidbodyCube.mass = 2;
                _countCube += 1;

                if (_countCube == 6)
                {
                    _gameArea.gameObject.SetActive(true);
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