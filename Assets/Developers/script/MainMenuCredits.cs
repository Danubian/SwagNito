using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainMenuCredits : MonoBehaviour
    {
        public void Callback_BtnCredits()
        {
            DBG.Log("callback btn goto title");
            Main.GetInstance().GotoMenu_Title();
        }
    }

}