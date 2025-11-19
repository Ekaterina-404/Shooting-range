using UnityEngine;

using Random = System.Random;

namespace ShootingRange
{
    public class ColorMaterialProvider : MonoBehaviour
    {
        private Color[] _colors =
            { Color.red, Color.blue, Color.green, Color.white, Color.yellow, Color.magenta, Color.grey };
        [SerializeField] private GameObject[] _cubes;
        private Random _random;
        private MaterialPropertyBlock _block;

        public void Start()
        {
            _random = new Random();
            ShuffleArray(_colors);
            _block = new MaterialPropertyBlock();
            SetColorCube(_cubes);
        }

        private void SetColorCube(GameObject[] cubes)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                var mesh = _cubes[i].GetComponent<MeshRenderer>();
                _block.SetColor("_BaseColor", _colors[i]);
                mesh.SetPropertyBlock(_block);
            }
        }

        private void ShuffleArray(Color[] colors)
        {
            for (int i = colors.Length - 1; i > 0; i--)
            {
                int randomNumber = _random.Next(i - 1);
                var temp = colors[i];
                colors[i] = colors[randomNumber];
                colors[randomNumber] = temp;
            }
        }
    }
}