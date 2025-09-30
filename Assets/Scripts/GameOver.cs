using UnityEngine;
using UnityEngine.UI;

namespace ShootingRange
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;
        [SerializeField] private GameObject _environment;
        [SerializeField] private AudioSource _audio;
        [SerializeField] private Button _buttonRestart;

        public void EndTheGame()
        {
            _gameOverUI.SetActive(true);
            _environment.SetActive(false);
            _audio.Play();
            RemoveEffects();
        }

        private void RemoveEffects()
        {
            var effect = GameObject.FindGameObjectWithTag("Effect");
            Destroy(effect);
        }
    }
}