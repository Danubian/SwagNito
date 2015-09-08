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

        // Update is called once per frame
        void Update()
        {
            if( bDidStartColCont == false )
            {
                bDidStartColCont = true;

                colCont.ForceStart();
            }
        }

        public void OnLeftClick()
        {
            if (player != null)
            {
                player.MoveLeft();
            }
        }

        public void OnRightClick()
        {
            if (player != null)
            {
                player.MoveRight();
            }
        }
    }
}
