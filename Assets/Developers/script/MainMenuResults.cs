using UnityEngine;
using System.Collections;

namespace Developers
{
    public class MainMenuResults : MonoBehaviour
    {
        public UnityEngine.UI.Text _text_depth;
        public UnityEngine.UI.Text _text_level;

        void OnEnable()
        {
            Depth.text = Main.GetInstance().Progress.DepthString();
            Level.text = Main.GetInstance().Progress.LevelString();
        }

        public void Callback_BtnAgain()
        {
            DBG.Log("callback btn goto again");

            Main.GetInstance().LoadGame();
            gameObject.SetActive(false);
        }
        public void Callback_BtnConnect()
        {
            DBG.Log("callback btn goto connect");

            Main.GetInstance().GotoMenu_Connect();
        }

        public UnityEngine.UI.Text Depth { get { return _text_depth; } set { _text_depth = value; } }
        public UnityEngine.UI.Text Level { get { return _text_level; } set { _text_level = value; } }
    }

}