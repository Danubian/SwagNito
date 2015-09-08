using UnityEngine;
using System.Collections;

namespace Developers
{
    public class Main : MonoBehaviour
    {

        private static Main INSTANCE;
        public static Main GetInstance()
        {
            return INSTANCE;
        }

        private MainRegistry _registry;
        private MainPooling _pooling;
        private MainAudio _audio;
        private MainProgress _progress;
        private MainGame _game;

        GameObject _menu_title;
        GameObject _menu_credits;
        GameObject _menu_results;
        GameObject _menu_connect;


        public void Awake()
        {
            if (INSTANCE != null)
            {
                DBG.Log("ZACK WHAT THE FUCK DID YOU DO?!?!?!", LogSeverity.FATAL);
            }
            INSTANCE = this;
            DBG.Log("Created main.");

            _registry = gameObject.AddComponent<MainRegistry>();
            DBG.Log("Created registry.");

            _audio = gameObject.AddComponent<MainAudio>();
            _audio.ForceStart();
            DBG.Log("Created audio.");

            _progress = gameObject.AddComponent<MainProgress>();
            DBG.Log("Created progress.");

            //
            _pooling = gameObject.AddComponent<MainPooling>();
            DBG.Log("Created pools.");

            //
            _menu_title = PrefabLoader.Load(GlobalVars.PREFAB_NAME_MENU_TITLE,transform);
            _menu_credits = PrefabLoader.Load(GlobalVars.PREFAB_NAME_MENU_CREDITS, transform);
            _menu_results = PrefabLoader.Load(GlobalVars.PREFAB_NAME_MENU_RESULTS, transform);
            _menu_connect = PrefabLoader.Load(GlobalVars.PREFAB_NAME_MENU_CONNECT, transform);

            DBG.Log("Created menus.");

            //
            GotoMenu_Title();
        }

        public MainPooling Pools { get { return _pooling; } }
        public MainProgress Progress { get { return _progress; } }
        public MainAudio Audio { get { return _audio; } }
        public MainRegistry Registry { get { return _registry; } }
        public MainGame Game { get { return _game; } }

        public void LoadGame()
        {
            //  Trash any existing game.
            //
            if (_game != null)
            {
                _game.KillGame();
            }

            //  Play.
            //
            _game = PrefabLoader.Load(GlobalVars.PREFAB_NAME_GAME, transform).GetComponent<MainGame>();
            _game.gameObject.SetActive(true);

            //
            Main.GetInstance().Audio.PlayMusic_Game();

            DBG.Log("Starting game.");
        }
        public void KillGame()
        {
            if (_game != null)
            {
                _game.KillGame();

                //  Disable all game shit.
                //
                _registry.CleanupGame();
            }
        }

        private void _DisableMenus()
        {
            _menu_title.SetActive(false);
            _menu_credits.SetActive(false);
            _menu_results.SetActive(false);
            _menu_connect.SetActive(false);
        }
        public void GotoMenu_Title()
        {
            _DisableMenus();
            _menu_title.SetActive(true);

            //
            Main.GetInstance().Audio.PlayMusic_Title();
        }
        public void GotoMenu_Results()
        {
            _DisableMenus();
            _menu_results.SetActive(true);

            //
            Main.GetInstance().Audio.PlayMusic_Game();
        }
        public void GotoMenu_Credits()
        {
            _DisableMenus();
            _menu_credits.SetActive(true);

            //
            Main.GetInstance().Audio.PlayMusic_Game();
        }
        public void GotoMenu_Connect()
        {
            _DisableMenus();
            _menu_connect.SetActive(true);

            //
            Main.GetInstance().Audio.PlayMusic_Game();
        }
    }

}