using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainMenuTitle : MonoBehaviour
    {
        public void Callback_BtnFall()
        {
            DBG.Log("callback btn fall");

            Main.GetInstance().LoadGame();
            gameObject.SetActive(false);
        }
        public void Callback_BtnCredits()
        {
            DBG.Log("callback btn fall");

            Main.GetInstance().GotoMenu_Credits();
        }
    }
}