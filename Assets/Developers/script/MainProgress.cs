using UnityEngine;
using System.Collections;

namespace Developers
{

    public class MainProgress : MonoBehaviour
    {
        private int _best_depth;
        private int _best_level;

        private int _latest_depth;

        private int _prayer_success_rate;

        public int BestDepth { get { return _best_depth; } set { _best_depth = value; } }
        public int BestLevel {
			get 
			{ 
				return _best_level; 
			} 
			set 
			{ 
				_best_level = value; 
			} 
		}
        public int LatestDepth { get { return _latest_depth; } set { _latest_depth = value; } }

        public int Prayer_Success_Rate
        {
            get { return _prayer_success_rate; }
            set { _prayer_success_rate = value; }
        }

        void Start()
        {
            BestDepth = 0;
            BestLevel = 1;
        }

        public string DepthString()
        {
            //  max 9 characters of numbers.
            string depth_string = BestDepth.ToString();
            if (depth_string.Length > 9)
                depth_string = depth_string.Substring(0, 9);

            return depth_string + "u";
        }
        public string LevelString()
        {
            //  max 9 characters of numbers.
            string level_string = BestLevel.ToString();
            if (level_string.Length > 9)
                level_string = level_string.Substring(0, 9);

            return "Lvl" + level_string;
        }
    }

}