using UnityEngine;
using System.Collections;

namespace Developers
{

    public class Asteroid : SwagObject
    {
        private static float Y_BUFFER = 1f;
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
                transform.position = new Vector3(pos.x, pos.y + .5f, pos.z);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("Asteroid Triggered");
            //		Destroy(other.gameObject);
        }

        public void Setup(int index)
        {
            MoveToBottom();
            Move(index);
        }

        public void MoveToBottom()
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, colControl.bottomBound + Y_BUFFER, pos.z);
        }

        private bool InVertBounds()
        {
            //TODO
            //		return true;
            return colControl.InVertBounds(this.transform.position.y, Y_BUFFER);
        }
    }
}
