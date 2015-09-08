﻿using UnityEngine;
using System.Collections;

namespace Developers
{
    public class SwagObject : MonoBehaviour
    {
		public enum Type {
			PLAYER,
			ASTEROID,
			BULLET
		}

		public Type entityType;

		public float speed;

        public ColumnController colControl;

        public int index;

        public void Move(int newIndex)
        {
            if (colControl.InColumnBounds(newIndex))
            {
                float newPosX = colControl.GetIndexPos(newIndex);
                Vector3 newPos = new Vector3(newPosX, transform.position.y, transform.position.z);
                this.transform.position = newPos;
                index = newIndex;
            }
        }

		void OnTriggerEnter(Collider other)
		{
			SwagObject otherObject = other.GetComponent<SwagObject>();
			int otherIndex = otherObject.index;
			if(otherIndex == this.index)
			{
				HandleCollision(otherObject.entityType);
			}
		}

		public virtual void Setup(int index)
		{
			Move(index);
		}

		public virtual void HandleCollision(Type other)
		{
			Debug.LogError("SwagObject : HandleCollision" + other.ToString());
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