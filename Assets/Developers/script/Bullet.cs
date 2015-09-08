using UnityEngine;
using System.Collections;

namespace Developers
{
	public class Bullet : SwagObject {
		
		// Use this for initialization
		void Start () {
			this.entityType = Type.BULLET;
			speed = GlobalVars.BULLET_SPEED;
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
				//Destroy(this.gameObject);
				OnDestroy();
			}
		}

		public override void Setup(int index)
		{
			this.index = index;
		}

		public override void HandleCollision(Type other)
		{
			Debug.Log("Bullet : HandleCollision " + other.ToString() + ", eval: " + (other == Type.ASTEROID));
			if(other == Type.ASTEROID)
			{
				Debug.LogError("Object Destroyed " + this.name);
				OnDestroy();
			}
		}
	}
}
