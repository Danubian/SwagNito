using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Developers
{
    public class LevelBarController : MonoBehaviour
    {
        public GameObject _levelUpFlash;
		public Image xpBar;

        public void Start()
        {
			Main.GetInstance().Progress.levelBar = this;
			xpBar.fillAmount = 0f;
		}

		public void UpdateDisplay()
		{
			int currentLevel = Main.GetInstance().Progress.level;
			int lastLevel = Main.GetInstance().Progress.lastLevel;
			int xp = Main.GetInstance().Progress.xp;

			float xpPercent = (1f * xp % GlobalVars.LEVEL_UP_EXP) / GlobalVars.LEVEL_UP_EXP;
			Debug.LogWarning("xpPercent: " + xpPercent + ", xp: " + xp);
			xpBar.fillAmount = xpPercent;

			Debug.LogError("Current: " + currentLevel + ", Last: " + lastLevel);
			if(currentLevel > lastLevel)
			{
				ShowLevelUp();
			}
		}

        private void ShowLevelUp()
        {
            _levelUpFlash.SetActive(true);
            StartCoroutine("DisableFlash");
        }
        private IEnumerator DisableFlash()
        {
            yield return new WaitForSeconds(2.0f);
            _levelUpFlash.SetActive(false);
        }
    }

}