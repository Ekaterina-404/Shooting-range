using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ShootingRange
{
    public class BulletColor : MonoBehaviour
    {
        [SerializeField] private Material[] _materials;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Material _material;

        public void GetRandomMaterial()

        {
            var rendererSphere = GetComponent<Renderer>();
            rendererSphere.material = _materials[Random.Range(0, _materials.Length)];
        }
    }
}