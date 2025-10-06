using UnityEngine;

namespace ShootingRange
{
    public class AmmoTracker : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chargeBullet;

        internal int AmmoBullet;
        private int _ammoBulletMax = 5;

        private void Awake()
        {
            ResetAmmoBullet();
        }

        internal void SpendAmmoBullet()
        {
            //1 бр. 5 сф. - пул. остаток 4 (5 вык) /2 бр. 4 сф. - остаток 3 (4 вык) /3 бр. 3 сф. - остаток 2 (3 вык) /4 бр. 2 сф. - остаток 1 (2 вык)
            switch (AmmoBullet)
            {
                case 5:
                    AmmoBullet -= 1; //из 5 пулей осталось 4
                    SpendChargeBullet(0); //выключаем 5 пулю остается 4
                    break;
                    
                case 4:
                    AmmoBullet -= 1; //из 4 пулей осталось 3
                    SpendChargeBullet(1); //выключаем 4 пулю остается 3
                    break;

                case 3:
                    AmmoBullet -= 1; //из 3 пул осталось 2
                    SpendChargeBullet(2); //выключаем 3 пулю осталось 2
                    break;

                case 2:
                    AmmoBullet -= 1; //из 2 пул осталось 1
                    SpendChargeBullet(3); //выключаем 2 пулю осталось 1
                    break;

                case 1:
                    AmmoBullet -= 1; //из 1 пул осталось 0
                    SpendChargeBullet(4); //выключаем 1 пулю осталось 0
                    Debug.Log("Перезарядка");
                    Invoke(nameof(ReloadChargeBullet), 1.2f);
                    Invoke(nameof(ResetAmmoBullet), 1.5f);
                    break;
            }
        }

        public void ResetAmmoBullet()
        {
            AmmoBullet = _ammoBulletMax;
        }

        private void SpendChargeBullet(int numberBullet)
        {
            _chargeBullet[numberBullet].SetActive(false);
        }

        public void ReloadChargeBullet()
        {
            foreach (var bullet in _chargeBullet)
            {
                bullet.SetActive(true);
            }
        }
    }
}