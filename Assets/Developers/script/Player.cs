using UnityEngine;
using System.Collections;

namespace Developers
{

    public class Player : SwagObject
    {
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
			this.entityType = Type.PLAYER;
            Move(4);
        }

        // Update is called once per frame
//        void Update()
//        {
//
//        }

        public void MoveLeft()
        {
            Move(index - 1);
			SpawnBullet();
        }

        public void MoveRight()
        {
            Move(index + 1);
			SpawnBullet();
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

		public override void HandleCollision(Type other)
		{
//			Debug.Log("Player : HandleCollision" + other.ToString());
		}
    }
}
