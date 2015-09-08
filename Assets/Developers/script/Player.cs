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
        }

        public void MoveRight()
        {
            Move(index + 1);
        }

		public override void HandleCollision()
		{
			Debug.Log("Player : HandleCollision");
		}
    }
}
