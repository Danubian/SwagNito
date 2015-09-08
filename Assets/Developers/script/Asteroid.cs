using UnityEngine;
using System.Collections;

namespace Developers
{

    public class Asteroid : SwagObject
	{
        // Use this for initialization
        void Start()
        {
			this.entityType = Type.ASTEROID;
			speed = GlobalVars.ASTEROID_SPEED;

            _rotateRate = UnityEngine.Random.Range(-3, 3);

            _randScale = UnityEngine.Random.Range(0.8f, 2f);
            transform.localScale = Vector3.one * _randScale;
        }

        // Update is called once per frame
        private float _rotateRate;
        private float _randScale;
        void Update()
        {
            //
            transform.rotation *= Quaternion.Euler(Vector3.forward * _rotateRate);

            //
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
			DBG.Log("Asteroid : HandleCollision : " + other.ToString());
			if(other != Type.ASTEROID)
			{
                if (Main.GetInstance().Game != null && other == Type.BULLET)
                {
                    Main.GetInstance().Game.StepLevel();
                }

                DBG.Log("Object Destroyed " + this.name);
				OnDestroy();
			}
		}
    }
}
