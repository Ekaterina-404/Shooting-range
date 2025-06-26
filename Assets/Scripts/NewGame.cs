using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShootingRange
{
    public class NewGame : MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}