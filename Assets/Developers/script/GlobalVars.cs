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

        public const string PREFAB_NAME_PRAYER_OFFERING = "PrayerOffering";
        public const string PREFAB_NAME_PRAYER_ANSWER = "PrayerAnswered";
        public const string PREFAB_NAME_PRAYER_IGNORE = "PrayerIgnored";

        public const float ASTEROID_SPAWN_TIME = 1f;
        public const float ASTEROID_SPEED = .05f;

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

        public const int RATE_PRAYER_SUCCESS = 15;
        public const int BASE_RATE_PRAYER_SUCCESS = 45;
        public const int DURATION_PRAYER_IGNORED = 3;
        public const int DURATION_PRAYER_ANSWERED = 2;
        public const int RATE_TICK_PRAYER_SPAWN = 30;
        public const int COOLDOWN_PRAYER = 3;
    }
}
