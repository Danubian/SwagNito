using UnityEngine;
using System.Collections.Generic;

namespace Developers
{

    public class Pool
    {
        private List<GameObject> _objects = new List<GameObject>();
        private int _last_index = 0;

        public void ForceStart(int size, string prefab, Transform parent_transform)
        {
            for( int ii=0; ii<size; ++ii )
            {
                GameObject instance = PrefabLoader.Load(prefab);
                instance.SetActive(false);
                instance.transform.parent = parent_transform;
                _objects.Add(instance);
            }
        }

        public GameObject Get()
        {
            //  Max N steps to find a free object.
            //
            int count = 0;
            GameObject temp = null;
            while( count < _objects.Count)
            {
                //  Assumes that "Not Active == Is Available".
                //
                temp = _objects[_last_index];
                if( temp.activeSelf == false )
                {
                    temp.SetActive(true);
                    return temp;
                }

                //  Step.
                //
                ++count;
                ++_last_index;
                if (_last_index >= _objects.Count)
                    _last_index = 0;
            }

            //
            return null;
        }
    }

    public class MainPooling : MonoBehaviour
    {
        private Pool _asteroids = new Pool();
        private Pool _bullets = new Pool();
        private Pool _effect_bullet_hit_asteroid = new Pool();
        private Pool _effect_level_up = new Pool();

        private GameObject _pooling_parent;

        void Awake()
        {
            //
            _pooling_parent = new GameObject("pooling parent");
            _pooling_parent.transform.parent = transform;

            //
            _asteroids.ForceStart(GlobalVars.POOL_SIZE_SMALL, GlobalVars.PREFAB_NAME_ASTEROID_1, _pooling_parent.transform);
            //_bullets.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_BULLET, _pooling_parent.transform);
            //_effect_bullet_hit_asteroid.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_EFFECT_BULLET_HIT_ASTEROID, _pooling_parent.transform);
            //_effect_level_up.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_EFFECT_LEVEL_UP, _pooling_parent.transform);
        }

        public GameObject Get_Asteroid() { return _asteroids.Get(); }
        public GameObject Get_Bullet() { return _bullets.Get(); }
        public GameObject Get_Effect_Bullet_Hit_Asteroid() { return _effect_bullet_hit_asteroid.Get(); }
        public GameObject Get_Effect_Level_Up() { return _effect_level_up.Get(); }
    }

}