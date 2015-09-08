using UnityEngine;
using System.Collections;

namespace Developers
{

    public class SwagObject : MonoBehaviour
    {

        public ColumnController colControl;

        public int index;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

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
			int otherIndex = other.GetComponent<SwagObject>().index;

			if(otherIndex == this.index)
			{
				HandleCollision();
			}
			//		Destroy(other.gameObject);
		}

		public virtual void HandleCollision()
		{
		}

        //	private bool moveLock = false;
        //	private IEnumerator MoveToPosition(Vector3 startPos, Vector3 endPos, float time)
        //	{
        //		moveLock = true;
        //		float elapsedTime = 0;
        //		this.transform.position = startPos;
        //		
        //		while (elapsedTime < time)
        //		{
        //			this.transform.position = Vector3.Lerp(this.transform.position, endPos, (elapsedTime / time));
        //			elapsedTime += Time.deltaTime;
        //			yield return null;
        //		}
        //		moveLock = false;
        //	}
    }

}