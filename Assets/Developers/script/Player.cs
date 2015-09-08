using UnityEngine;
using System.Collections;

namespace Developers
{

    public class Player : SwagObject
    {
        public GameObject _graphics;
        //	public float horizontalSpeed;
        //	public RectTransform boundaries;
        //	public float leftBound;
        //	public float rightBound;
        //	public float basePos;
        //	private float width = 1f;
        //	public int max; 
        //	public float chunkSize;
        //	public float length;

        // Use this for initialization
        void Start()
        {
            Move(4);
        }

        void Update()
        {

            //
            _graphics.transform.rotation *= Quaternion.Euler(Vector3.forward * GlobalVars.RATE_PLAYER_SPIN);
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
        public override void HandleCollision(Type other)
		{
            if( bAlive == true )
            {
                Debug.Log("Player : HandleCollision");

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

        private IEnumerator GotoResults()
        {
            yield return new WaitForSeconds(2.0f);

            Main.GetInstance().KillGame();
            Main.GetInstance().GotoMenu_Results();
        }

		public void SpawnBullet()
		{
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
