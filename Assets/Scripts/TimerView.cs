using TMPro;

using UnityEngine;

namespace ShootingRange
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textContainer;

        public void SetTime(float time)
        {
            _textContainer.text = time.ToString("0.00");
        }
    }
}