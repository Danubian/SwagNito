using UnityEngine;
using System.Collections;

namespace Developers
{
    public class GlobalVars
    {
        public const int POOL_SIZE_SMALL = 15;
        public const int POOL_SIZE_MEDIUM = 50;
        
        public const string PREFAB_NAME_GAME = "Game";

        public const string PREFAB_NAME_MENU_TITLE = "MenuTitle";
        public const string PREFAB_NAME_MENU_RESULTS = "MenuResults";
        public const string PREFAB_NAME_MENU_CREDITS = "MenuCredits";
        public const string PREFAB_NAME_MENU_CONNECT = "MenuConnect";

        public const string PREFAB_NAME_ASTEROID_1 = "Asteroid1";
        public const string PREFAB_NAME_ASTEROID_2 = "Asteroid2";
        public const string PREFAB_NAME_ASTEROID_3 = "Asteroid3";

        public const string PREFAB_NAME_BULLET = "bullet";
        public const string PREFAB_NAME_EFFECT_BULLET_HIT_ASTEROID = "Effect_bullet_hit_asteroid";
        public const string PREFAB_NAME_EFFECT_PLAYER_HIT_ASTEROID = "Effect_player_hit_asteroid";
        public const string PREFAB_NAME_EFFECT_LEVEL_UP = "effect_bullet_level_up";

		public const float ASTEROID_SPAWN_TIME = 0.3f;
        public const float ASTEROID_SPEED = .125f;

        public const float ASTEROID_SPEED_RAMP = 0.1f;

		public const float BULLET_SPEED = -.0625f;
        public const float FIRE_COOLDOWN = 0.5f;

		public const int COLUMNS_TOTAL = 9;
		public const int COLUMNS_CENTER_INDEX = COLUMNS_TOTAL / 2;

		public const float VERT_DEPTH_BUFFER = 1f;

        public const float RATE_PLAYER_SPIN = 2f;

        public const int MIN_LEVEL_BAR_Y = -10;
        public const int MAX_LEVEL_BAR_Y = 0;
        public const float RATE_STEP_LEVEL_BAR_Y = 0.5f;
		public const int ASTEROID_LEVEL = 10;
		public const int LEVEL_UP_EXP = 100;
    }
}
