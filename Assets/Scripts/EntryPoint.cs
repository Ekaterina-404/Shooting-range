using System.Collections.Generic;

using UnityEngine;

namespace ShootingRange
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Timer _timer;

        private void Start()
        {
            _timer.StartTimer();
            //StartCoroutine("WaitAndStart");
        }

        /*IEnumerable<WaitForSeconds> WaitAndStart()
        {
            yield return new WaitForSeconds(1.33f);
        }
        */
    }
}