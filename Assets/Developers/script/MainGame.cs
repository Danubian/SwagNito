using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainGame : MonoBehaviour
    {
        public LevelBarController _levelBar;
        public bool _bPrayerUp = false;
        private bool _bPrayerCooling = false;

        void Start()
        {
            StartCoroutine("_TickCreatePrayer");
        }

        public void KillGame()
        {
            DBG.Log("Destroying game.");
            Destroy(gameObject);
        }

        void Update()
        {
            if( Input.GetKey(KeyCode.T) == true)
            {
                Main.GetInstance().GotoMenu_Results();
                Main.GetInstance().KillGame();
            }

            //  Test out bullet hit asteroid effect.
            //
            //if( Input.GetMouseButton(0) == true )
            //{
            //    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //    pos.z = 0;

            //    GameObject effect = Main.GetInstance().Pools.Get_Effect_Bullet_Hit_Asteroid();
            //    if (effect != null)
            //    {
            //        effect.transform.position = pos;
            //    }
            //}
        }

        public void StepLevel()
        {
            _levelBar.Step();
        }

        private IEnumerator _TickCreatePrayer()
        {
            for (;;)
            {
                yield return new WaitForSeconds(GlobalVars.RATE_TICK_PRAYER_SPAWN);

                CreatePrayer();
            }
        }

        public void CreatePrayer()
        {
            if(_bPrayerCooling == false && _bPrayerUp == false)
            {
                _bPrayerUp = true;
                _bPrayerCooling = true;
                StartCoroutine("_FinishCooldownPrayer");
                
                    GameObject go = Main.GetInstance().Pools.Get_Prayer();
                    go.SetActive(true);
;            }
        }
        private IEnumerator _FinishCooldownPrayer()
        {
            yield return new WaitForSeconds(GlobalVars.COOLDOWN_PRAYER);
            _bPrayerCooling = false;
        }
    }

}
