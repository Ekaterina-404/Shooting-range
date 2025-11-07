using UnityEngine;

namespace ShootingRange
{
    public class MaterialProvider : MonoBehaviour
    {
        [SerializeField] private Material[] _materials;

        public Material GetRandomMaterial()
        {
            return _materials[Random.Range(0, _materials.Length)];
        }
    }
}