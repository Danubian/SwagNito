using UnityEngine;
using System.Collections;

namespace Developers
{

    public class MainProgress : MonoBehaviour
    {
		public LevelBarController levelBar;

        private int m_best_depth;
        private int m_best_level;

		private int m_last_depth;
		private int m_last_level;
		
		private int m_depth;
		private int m_level;

		private int m_xp;

		public int lastDepth { get { return m_last_depth; } }
		public int lastLevel { get { return m_last_level; } }

        public int bestDepth { get { return m_best_depth; } set { m_best_depth = value; } }
        public int bestLevel { get { return m_best_level; } set { m_best_level = value; } }

		public int depth { 
			get { return m_depth; } 
			set {
				m_last_depth = m_depth;
				m_depth = value;
				if(m_depth > bestDepth)
				{
					bestDepth = m_depth;
				}
			} 
		}

		public int xp { 
			get { return m_xp; } 
			set {
//				Debug.LogWarning("XP: " + m_xp + ", value : " + value);
				level = value / GlobalVars.LEVEL_UP_EXP;
//				Debug.Log("Level: " + level);
				levelBar.UpdateDisplay();
				
				m_xp = value;
			} 
		}

		public int level { 
			get { return m_level; } 
			set {
				m_last_level = m_level;
				m_level = value;
				if(m_level > bestLevel)
				{
					bestLevel = m_level;
				}
			} 
		}

        void Start()
        {
            bestDepth = 0;
            bestLevel = 1;
        }

        public string DepthString()
        {
            //  max 9 characters of numbers.
            string depth_string = bestDepth.ToString();
            if (depth_string.Length > 9)
                depth_string = depth_string.Substring(0, 9);

            return depth_string + "u";
        }

        public string LevelString()
        {
            //  max 9 characters of numbers.
            string level_string = bestLevel.ToString();
            if (level_string.Length > 9)
                level_string = level_string.Substring(0, 9);

            return level_string;
        }
    }

}