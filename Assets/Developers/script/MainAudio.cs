using UnityEngine;
using System.Collections.Generic;

namespace Developers
{
    public class MainAudio : MonoBehaviour
    {
        //
        private Dictionary<string, AudioClip> _fx_clips = new Dictionary<string, AudioClip>();

        //
        public void ForceStart()
        {
            //  Load FX.
            //
            _fx_clips["death1"] = (AudioClip)Resources.Load("death1");
            _fx_clips["death2"] = (AudioClip)Resources.Load("death2");

            _fx_clips["hit1"] = (AudioClip)Resources.Load("hit1");
            _fx_clips["hit2"] = (AudioClip)Resources.Load("hit2");
            _fx_clips["hit3"] = (AudioClip)Resources.Load("hit3");
            _fx_clips["hit4"] = (AudioClip)Resources.Load("hit4");
            _fx_clips["hit5"] = (AudioClip)Resources.Load("hit5");

            _fx_clips["gameStart1"] = (AudioClip)Resources.Load("gameStart1");

            _fx_clips["levelup1"] = (AudioClip)Resources.Load("levelup1");

            _fx_clips["shoot1"] = (AudioClip)Resources.Load("shoot1");

            _fx_clips["spawn1"] = (AudioClip)Resources.Load("spawn1");

            _fx_clips["title1"] = (AudioClip)Resources.Load("title1");
        }

        private static void _PlayClip(AudioClip clip)
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position);
        }

        public void PlayFX_PlayerDeath() { _PlayClip(_fx_clips["death1"]); }

        public void PlayFX_PlayerShoot() { _PlayClip(_fx_clips["shoot1"]); }
        public void PlayFX_PlayerLevelUp() { _PlayClip(_fx_clips["levelup1"]); }

        public void PlayMusic_SpawnAsteroid() { _PlayClip(_fx_clips["spawn1"]); }

        public void PlayFX_BulletHitAsteroid() { _PlayClip(_fx_clips["hit2"]); }
        public void PlayFX_PlayerHitAsteroid() { _PlayClip(_fx_clips["hit4"]); }

        public void PlayMusic_Title() { _PlayClip(_fx_clips["title1"]); }
        public void PlayMusic_Game() { _PlayClip(_fx_clips["gameStart1"]); }
        public void PlayMusic_ResultsConnectCredits() { _PlayClip(_fx_clips["gameStart1"]); }
    }

}