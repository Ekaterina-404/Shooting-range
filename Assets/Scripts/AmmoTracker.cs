using UnityEngine;

namespace ShootingRange
{
    public class AmmoTracker : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chargeBullet;

        public int AmmoBullet;
        private int _ammoBulletMax = 4;

        private void Awake()
        {
            ResetAmmoBullet();
        }

        public void SpendAmmoBullet()

        {
            SpendChargeBullet(_ammoBulletMax - AmmoBullet);
            AmmoBullet -= 1;

            if (AmmoBullet == 0)
            {
                Debug.Log("Перезарядка");
                Invoke(nameof(ReloadChargeBullet), 1.2f);
                Invoke(nameof(ResetAmmoBullet), 1.5f);
            }
        }

        public void ResetAmmoBullet()
        {
            AmmoBullet = _ammoBulletMax;
        }

        public void ReloadChargeBullet()
        {
            foreach (var bullet in _chargeBullet)
            {
                bullet.SetActive(true);
            }
        }

        private void SpendChargeBullet(int numberBullet)
        {
            _chargeBullet[numberBullet].SetActive(false);
        }
    }
}