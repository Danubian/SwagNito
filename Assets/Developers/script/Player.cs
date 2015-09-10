using UnityEngine;
using System.Collections;

namespace Developers
{
    public class Player : SwagObject
    {
		public GameObject _graphics;

        void Start()
        {
            Move(4);
        }

        void Update()
        {
            _graphics.transform.rotation *= Quaternion.Euler(Vector3.forward * 2f);
        }

        public void MoveLeft()
        {
            if (bAlive == false)
                return;

            Move(index - 1);
            SpawnBullet();
        }

        public void MoveRight()
        {
            if (bAlive == false)
                return;

            Move(index + 1);
            SpawnBullet();
        }

		bool bAlive = true;
        public override void HandleCollision(SwagObject other)
		{
            if( bAlive == true )
            {
                Debug.Log("Player : HandleCollision");


                //
                if (other.entityType == Type.ASTEROID)
                {
                    bAlive = false;

                    GameObject effect = Main.GetInstance().Pools.Get_Effect_Player_Hit_Asteroid();
                    if (effect != null)
                    {
                        effect.transform.position = transform.position;
                    }

                    _graphics.SetActive(false);
                    StartCoroutine("GotoResults");

                    //
                    Main.GetInstance().Audio.PlayFX_PlayerDeath();
                }


            }

		}

        private IEnumerator GotoResults()
        {
            yield return new WaitForSeconds(2.0f);

            Main.GetInstance().KillGame();
            Main.GetInstance().GotoMenu_Results();
        }

		private float lastSpawnTime;
		public void SpawnBullet()
		{
			if((Time.time - lastSpawnTime) >= GlobalVars.FIRE_COOLDOWN)
			{
				lastSpawnTime = Time.time;

				GameObject bullet = Main.GetInstance().Pools.Get_Bullet();
				if( bullet != null )
				{
					Bullet bulletController = bullet.GetComponent<Bullet>();
					bulletController.colControl = colControl;
					bulletController.Setup(this.index);
					bullet.transform.position = this.transform.position;
					
					Main.GetInstance().Audio.PlayFX_PlayerShoot();
				}
			}
		}
    }
}
