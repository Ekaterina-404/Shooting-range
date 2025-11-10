using UnityEngine;

using Random = System.Random;

namespace ShootingRange
{
    public class ColorMaterialProvider : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;//для проверки работы MaterialPropertyBlock

        private Color[] _colors =
            { Color.red, Color.blue, Color.green, Color.white, Color.yellow, Color.magenta, Color.grey };
        private Random _random;

        public void Start()
        {
            _random = new Random();
            ShuffleArray(_colors);
            var cube = Instantiate(_prefab); //для проверки
            MaterialPropertyBlock block = new MaterialPropertyBlock();
            block.SetColor("_Color",Color.blue);
            cube.GetComponent<MeshRenderer>().SetPropertyBlock(block);
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
        /*private void SetColorCube(GameObject[] cubes)
        {
            for (int i = 0; i < cubes.Length; i++)
            {
                var mesh = _cubes[i].GetComponent<MeshRenderer>();
                _block.SetColor(_color, _colors[i]);
                mesh.SetPropertyBlock(_block);
            }
        }*/
    }
}
