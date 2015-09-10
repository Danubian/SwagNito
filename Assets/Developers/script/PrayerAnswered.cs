using UnityEngine;
using System.Collections;


namespace Developers
{
    public class PrayerAnswered : MonoBehaviour
    {
        void OnEnable()
        {
            StartCoroutine("Disable");
        }

        void Update()
        {
            KillAllShit();
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(GlobalVars.DURATION_PRAYER_ANSWERED);
            gameObject.SetActive(false);
            yield return null;
        }

        private void KillAllShit()
        {
            foreach (GameObject go in Main.GetInstance().Registry.Asteroids)
            {
                SwagObject so = go.GetComponent<SwagObject>();
                if( so != null )
                {
                    so.Kill();

                    GameObject effect1 = Main.GetInstance().Pools.Get_Effect_Bullet_Hit_Asteroid();
                    if (effect1 != null)
                    {
                        effect1.transform.position = so.transform.position;
                    }

                    GameObject effect2 = Main.GetInstance().Pools.Get_Effect_Bullet_Hit_Asteroid();
                    if (effect2 != null)
                    {
                        effect2.transform.position = go.transform.position;
                    }
                }

            }

        }
    }
}