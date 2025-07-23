using UnityEngine;

namespace ShootingRange
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverUI;

        public void EndTheGame()
        {
            _gameOverUI.SetActive(true);
        }
    }
}