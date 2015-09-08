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

        public void MoveLeft()
        {
            Move(index - 1);
        }

        public void MoveRight()
        {
            Move(index + 1);
        }

		bool bAlive = true;
		public override void HandleCollision()
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
			}
		}
    }
}
