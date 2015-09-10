using UnityEngine;
using System.Collections.Generic;

namespace Developers
{
    public class MainRegistry : MonoBehaviour
    {
        private GameObject _player = null;
        private List<GameObject> _effects = new List<GameObject>();
        private List<GameObject> _asteroids = new List<GameObject>();
        private List<GameObject> _bullets = new List<GameObject>();
        private List<GameObject> _prayer = new List<GameObject>();

        public GameObject Player { get { return _player; } set { _player = value; } }
        public List<GameObject> Effects { get { return _effects; } }
        public List<GameObject> Asteroids { get { return _asteroids; } }
        public List<GameObject> Bullets { get { return _bullets; } }
        public List<GameObject> Prayer { get { return _prayer; } set { _prayer = value; } }

        public void CleanupGame()
        {
            foreach (GameObject ast in Asteroids)
                ast.SetActive(false);
            foreach (GameObject e in Effects)
                e.SetActive(false);
            foreach (GameObject b in Bullets)
                b.SetActive(false);
            foreach (GameObject p in Prayer)
                p.SetActive(false);

            //
            DBG.Log("Cleaned up all game actors.");
        }
    }

}