using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainMenuConnect : MonoBehaviour
    {
        public void Callback_BtnResults()
        {
            DBG.Log("callback btn results");
            Main.GetInstance().GotoMenu_Results();
        }
        public void Callback_BtnFacebook()
        {
            DBG.Log("callback btn face");
        }
        public void Callback_BtnTwitter()
        {
            DBG.Log("callback btn twitt");
        }
    }

}