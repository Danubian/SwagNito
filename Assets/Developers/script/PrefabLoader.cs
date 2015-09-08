using UnityEngine;
using System.Collections;

namespace Developers
{

    public class PrefabLoader : MonoBehaviour
    {
        public static GameObject Load(string name, Transform parent = null)
        {
            GameObject created = (GameObject)Instantiate(Resources.Load(name));

            if (parent != null)
                created.transform.parent = parent;

            return created;
        }
    }

}