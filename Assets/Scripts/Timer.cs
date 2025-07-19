using TMPro;
using UnityEngine;

namespace ShootingRange
{
    public class Timer : MonoBehaviour

    {
        [SerializeField] private bool _start;
        [SerializeField] private TextMeshProUGUI _timer;
        private float _time;

        private void Update()
        {
            if (_start == true)
            {
                _time += Time.deltaTime;
                _timer.text = _time.ToString("0.00");
            }
        }

        public void StartTimer()
        {
            _start = true;
        }

        public void PauseTimer()
        {
            _start = false;
        }

        public void StopTimer()
        {
            _start = false;
            _time = 0;
            _timer.text = _time.ToString("0.00");
        }
    }
}