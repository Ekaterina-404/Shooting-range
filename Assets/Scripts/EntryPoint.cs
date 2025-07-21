using System;

using UnityEngine;

namespace ShootingRange
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Timer _timer;

        private void Start()
        {
            _timer.StartTimer();
        }
    }
}