using UnityEngine;
using System.Collections;

namespace Developers
{
    public class Asteroid : SwagObject
	{
        void Start()
        {
			this.entityType = Type.ASTEROID;
        }

        void Update()
        {
            if (InVertBounds())
            {
                Vector3 pos = transform.position;
				float newPosY = pos.y + speed;
                transform.position = new Vector3(pos.x, newPosY, pos.z);
            }
            else
            {
				OnDestroy();
            }
        }

        public void Setup(int index, float speed)
        {
			base.Setup(index);
            MoveToBottom();
			this.speed = speed;
        }

        public void MoveToBottom()
        {
            Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x, colControl.bottomBound - GlobalVars.VERT_DEPTH_BUFFER, pos.z);
        }

		public override void HandleCollision(Type other)
		{
			if(other != Type.ASTEROID)
			{
				OnDestroy();
			}
		}
    }
}
