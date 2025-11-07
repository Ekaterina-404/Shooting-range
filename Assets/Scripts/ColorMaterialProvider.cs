using System;

using UnityEngine;

using Random = System.Random;

public class ColorMaterialProvider : MonoBehaviour
{
    private string[] colors = { "red", "blue", "green", "white", "yellow", "magenta", "gray" }; //7 элементов от 0 до 6
    private Random random = new Random();

    private void Start()
    {
        ShuffleArray(colors);
    }

    private void ShuffleArray(string[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomNumber = random.Next(i - 1);
            string temp = array[i];
            array[i] = array[randomNumber];
            array[randomNumber] = temp;
        }
    }
}