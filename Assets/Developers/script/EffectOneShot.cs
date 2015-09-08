using UnityEngine;
using System.Collections;

namespace Developers
{
    public class EffectOneShot : MonoBehaviour
    {
        public ParticleSystem _ps;

        void Update()
        {
            if( _ps.IsAlive() == false )
            {
                gameObject.SetActive(false);
            }
        }
    }

}