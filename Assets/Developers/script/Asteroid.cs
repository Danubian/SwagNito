using UnityEngine;
using System.Collections;

namespace Developers
{

    public class Asteroid : SwagObject
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (InVertBounds())
            {
                Vector3 pos = transform.position;
				float newPosY = pos.y + GlobalVars.ASTEROID_SPEED;
                transform.position = new Vector3(pos.x, newPosY, pos.z);
            }
            else
            {
                //Destroy(this.gameObject);
                gameObject.SetActive(false);
            }
        }

        public void Setup(int index)
        {
            MoveToBottom();
            Move(index);
        }

        public void MoveToBottom()
        {
            Vector3 pos = transform.position;
			transform.position = new Vector3(pos.x, colControl.bottomBound - GlobalVars.VERT_DEPTH_BUFFER, pos.z);
        }

        private bool InVertBounds()
        {
            //TODO
            //		return true;
			return colControl.InVertBounds(this.transform.position.y, GlobalVars.VERT_DEPTH_BUFFER);
        }

		public override void HandleCollision()
		{
			Destroy(this.transform.gameObject);
		}
    }
}
