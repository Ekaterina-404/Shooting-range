using UnityEngine;

namespace ShootingRange
{
    public class GameFinishTrigger : MonoBehaviour
    {
        [SerializeField] private int _targetsCount = 6;
        [SerializeField] private Timer _timer;

        private int _targetsRemaining;

        private void Start()
        {
            _targetsRemaining = _targetsCount;
        }

        public void DecreaseTargetsCount()
        {
            _targetsRemaining = _targetsRemaining - 1;

            if (_targetsRemaining <= 0)
            {
                _timer.StopTimer();
            }
        }
    }
}