using UnityEngine;

namespace ShootingRange
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TimerView _timerView;
        private bool _isActive;
        private float _time;

        private void Update()
        {
            if (_isActive)
            {
                _time += Time.deltaTime;
                _timerView.SetTime(_time);
            }
        }

        public void StartTimer()
        {
            StopTimer();
            _isActive = true;
        }

        public void StopTimer()
        {
            _isActive = false;
            _time = 0;
            _timerView.SetTime(_time);
        }
    }
}