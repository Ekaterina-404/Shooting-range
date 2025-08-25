using UnityEngine;
using UnityEngine.UI;

namespace ShootingRange
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private Button _buttonRestart;

        public void EndTheGame()
        {
            _gameOverUI.SetActive(true);
            _audio.Play();

        }
    }
}