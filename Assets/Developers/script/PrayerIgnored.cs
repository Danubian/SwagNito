using UnityEngine;
using System.Collections;

namespace Developers
{
    public class PrayerIgnored : MonoBehaviour
    {
        public GameObject _text;
        public float _rate = 5.0f;
        public float _start = 10;
        public float _end = -10;

        void OnEnable()
        {
            _text.transform.localPosition = new Vector3(_start, 0, 0);

            StartCoroutine("Disable");
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(GlobalVars.DURATION_PRAYER_IGNORED);
            gameObject.SetActive(false);
            yield return null;
        }

        // Update is called once per frame
        void Update()
        {
            //
            _text.transform.localPosition += Vector3.right * _rate * Time.deltaTime;

            //
            if (_text.transform.localPosition.x < _end)
                _text.transform.localPosition = new Vector3(_start, 0, 0);
        }
    }

}