using UnityEngine;
using System.Collections.Generic;

namespace Developers
{
    public class MainRegistry : MonoBehaviour
    {
        private List<GameObject> _live_in_scene = new List<GameObject>();
        private GameObject _player = null;

        public List<GameObject> Live_In_Scene { get { return _live_in_scene; } }
        public GameObject Player { get { return _player; } set { _player = value; } }
    }

}