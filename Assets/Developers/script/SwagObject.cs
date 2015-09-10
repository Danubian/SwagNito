using UnityEngine;

using System;
using System.Collections;

namespace Developers
{
    public class SwagObject : MonoBehaviour
    {
		public enum Type {
			PLAYER,
			ASTEROID,
			BULLET,
			UNKNOWN
		}

		public Type entityType;

		public float speed;

        public ColumnController colControl;

        public int index;

        public void Move(int newIndex, Action callback = null)
        {
            if (colControl.InColumnBounds(newIndex))
            {
                float newPosX = colControl.GetIndexPos(newIndex);
                Vector3 newPos = new Vector3(newPosX, transform.position.y, transform.position.z);
                this.transform.position = newPos;
                index = newIndex;

				if(callback != null)
				{
					callback();
				}
            }
        }

		void OnTriggerEnter(Collider other)
		{
			SwagObject otherObject = other.GetComponent<SwagObject>();
			if(otherObject != null)
            {
                HandleCollision(otherObject);
			} else {
				//HandleCollision(Type.UNKNOWN);
			}
		}

		public virtual void Setup(int index)
		{
			Move(index);
		}

        public virtual void HandleCollision(SwagObject other)
        {
            Debug.LogError("SwagObject : HandleCollision" + other.ToString());
        }
        public virtual void Kill()
        {
        }

        protected void OnDestroy()
		{
			gameObject.SetActive(false);
		}

		protected bool InVertBounds()
		{
			return colControl.InVertBounds(this.transform.position.y, GlobalVars.VERT_DEPTH_BUFFER);
		}
    }
}
