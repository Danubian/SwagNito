using UnityEngine;
using System.Collections;

namespace Developers
{
	public class Bullet : SwagObject {

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
				OnDestroy();
			}
		}

		public override void Setup(int index)
		{
			this.index = index;
		}

		public override void HandleCollision(Type other)
		{
            DBG.Log("Bullet : HandleCollision " + other.ToString() + ", eval: " + (other == Type.ASTEROID));
			if(other == Type.ASTEROID || other == Type.UNKNOWN)
			{
                GameObject effect = Main.GetInstance().Pools.Get_Effect_Bullet_Hit_Asteroid();
                if (effect != null)
                {
                    effect.transform.position = transform.position;
                }

				DBG.Log("Object Destroyed " + this.name);
				OnDestroy();
			}
		}
	}
}
