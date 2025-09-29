using UnityEngine;

namespace ShootingRange
{
    public class CubeMassController : MonoBehaviour
    {
        private int _countCube;
        private Rigidbody _rigidbodyCube;

        private void OnTriggerEnter(Collider colliderObject)
        {
            if (colliderObject.gameObject.CompareTag("Target"))
            {
                GameObject Cube = colliderObject.gameObject;
                _rigidbodyCube = Cube.GetComponent<Rigidbody>();
                _rigidbodyCube.mass = 1;
                _countCube += 1;

                if (_countCube == 6)
                {
                    Debug.Log("Все кубы на месте");
                }
            }
        }
    }
}