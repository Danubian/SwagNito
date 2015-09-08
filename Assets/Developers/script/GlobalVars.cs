﻿using UnityEngine;
using System.Collections;

namespace Developers
{
    public class GlobalVars
    {
        public const int POOL_SIZE_MEDIUM = 250;
        
        public const string PREFAB_NAME_GAME = "Game";

        public const string PREFAB_NAME_MENU_TITLE = "MenuTitle";
        public const string PREFAB_NAME_MENU_RESULTS = "MenuResults";
        public const string PREFAB_NAME_MENU_CREDITS = "MenuCredits";
        public const string PREFAB_NAME_MENU_CONNECT = "MenuConnect";

        public const string PREFAB_NAME_ASTEROID_1 = "asteroid_1";
        public const string PREFAB_NAME_BULLET = "bullet";
        public const string PREFAB_NAME_EFFECT_BULLET_HIT_ASTEROID = "effect_bullet_hit_asteroid";
        public const string PREFAB_NAME_EFFECT_LEVEL_UP = "effect_bullet_level_up";

		public const float ASTEROID_SPAWN_TIME = 1f;
		public const float ASTEROID_SPEED = .25f;

		public const int NUM_COLUMNS = 9;

		public const float VERT_DEPTH_BUFFER = 1f;
    }

}