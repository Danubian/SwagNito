using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainGame : MonoBehaviour
    {
        public void KillGame()
        {
            DBG.Log("Destroying game.");
            Destroy(gameObject);
        }

        void Update()
        {
            if( Input.GetKey(KeyCode.T) == true)
            {
                Main.GetInstance().GotoMenu_Results();
                Main.GetInstance().KillGame();
            }
        }
    }

}