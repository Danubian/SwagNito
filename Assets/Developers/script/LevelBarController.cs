using UnityEngine;
using System.Collections;

namespace Developers
{
    public class LevelBarController : MonoBehaviour
    {
        public GameObject _graphics;
        public GameObject _levelUpFlash;
        private Vector3 _tempV3;

        public void Start()
        {
            _graphics.transform.localPosition = new Vector3(_graphics.transform.localPosition.x, GlobalVars.MIN_LEVEL_BAR_Y, 0);
        }
        public void Step()
        {
            _tempV3 = _graphics.transform.localPosition;

            _tempV3.y += 0.5f;
            if (_tempV3.y >= GlobalVars.MAX_LEVEL_BAR_Y)
            {
                //  Level up.
                //
                _tempV3.y = GlobalVars.MIN_LEVEL_BAR_Y;
                ShowLevelUp();
                Main.GetInstance().Game.CreatePrayer();
            }

            _graphics.transform.localPosition = _tempV3;

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