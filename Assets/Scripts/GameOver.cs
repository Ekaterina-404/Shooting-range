using UnityEngine;
using UnityEngine.UI;

namespace ShootingRange
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _environment;
        [SerializeField] private GameObject _ammunition;
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private Button _buttonRestart;

        public void EndTheGame()
        {
            _environment.SetActive(false);
            _ammunition.SetActive(false);
            _gameOverUI.SetActive(true);
            _audio.Play();
        }
    }
}