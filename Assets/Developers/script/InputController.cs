using UnityEngine;
using System.Collections;

namespace Developers
{

    public class InputController : MonoBehaviour
    {
        public Player player;
        public ColumnController colCont;
        private bool bDidStartColCont;

        void Awake()
        {

            Canvas canv1 = gameObject.GetComponent<Canvas>();
            canv1.worldCamera = Camera.main;
        }

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if( bDidStartColCont == false )
            {
                bDidStartColCont = true;

                Vector3[] corners = new Vector3[4];
                GetComponent<RectTransform>().GetWorldCorners(corners);
//                foreach (Vector3 corner in corners)
//                {
//                    Debug.Log("Corner : " + corner.ToString());
//                }

                colCont.ForceStart();
            }
        }

        public void OnLeftClick()
        {
//            Debug.Log("Left Side Clicked");
            if (player != null)
            {
                player.MoveLeft();
            }
        }

        public void OnRightClick()
        {
//            Debug.Log("Right Side Clicked");
            if (player != null)
            {
                player.MoveRight();
            }
        }
    }
}
