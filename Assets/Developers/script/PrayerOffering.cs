using UnityEngine;
using System.Collections;

namespace Developers
{
    public class PrayerOffering : SwagObject
    {
        private bool _alive = false;

        void OnEnable()
        {
            _alive = true;
        }
        void Start()
        {

            Main.GetInstance().Progress.Prayer_Success_Rate = GlobalVars.BASE_RATE_PRAYER_SUCCESS;
            this.entityType = Type.ASTEROID;

            Main.GetInstance().Game._bPrayerUp = true;
        }

        public override void HandleCollision(SwagObject other)
        {
            if (_alive == true)
            {
                DBG.Log("PrayerOffering : HandleCollision : " + other.ToString());
                if (other.entityType == Type.BULLET)
                {
                    _alive = false;
                    //
                    _GiveMorePrayerChance();
                    _RollChanceAnswerPrayer();

                    //
                    Main.GetInstance().Game._bPrayerUp = false;

                    //
                    DBG.Log("Object Destroyed " + this.name);
                    OnDestroy();
                }
            }

        }

        private void _GiveMorePrayerChance()
        {
            Main.GetInstance().Progress.Prayer_Success_Rate += GlobalVars.RATE_PRAYER_SUCCESS;
        }

        private void _RollChanceAnswerPrayer()
        {
            int roll = UnityEngine.Random.Range(0, 100);

            if (roll <= Main.GetInstance().Progress.Prayer_Success_Rate)
            {
                Main.GetInstance().Progress.Prayer_Success_Rate = GlobalVars.BASE_RATE_PRAYER_SUCCESS;
                _AnswerPrayer();
            }
            else
            {
                _IgnorePrayer();
            }

        }

        private void _AnswerPrayer()
        {
            GameObject go = Main.GetInstance().Pools.Get_Prayer_Answered();
            go.SetActive(true);
        }
        private void _IgnorePrayer()
        {
            GameObject go = Main.GetInstance().Pools.Get_Prayer_Ignored();
            go.SetActive(true);
        }

    }

}