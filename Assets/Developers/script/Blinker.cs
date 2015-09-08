using UnityEngine;
using System.Collections;

namespace Developers
{
    public class Blinker : MonoBehaviour
    {
        public float _delay = 1.0f;
        private float _accumulated = 0;
        public GameObject _graphics;

        // Update is called once per frame
        void Update()
        {
            //
            if( _accumulated >= _delay )
            {
                _graphics.SetActive(!_graphics.activeSelf);
                _accumulated = 0;
            }

            //
            _accumulated += Time.deltaTime;
        }
    }

}