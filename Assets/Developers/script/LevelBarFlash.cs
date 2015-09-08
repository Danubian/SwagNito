using UnityEngine;
using System.Collections;


namespace Developers
{

    public class LevelBarFlash : MonoBehaviour
    {

        void OnEnable()
        {

            Main.GetInstance().Audio.PlayFX_PlayerLevelUp();
        }
    }

}