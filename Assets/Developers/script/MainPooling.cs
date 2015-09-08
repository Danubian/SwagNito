using UnityEngine;
using System.Collections.Generic;

namespace Developers
{

    public class Pool
    {
        private List<GameObject> _objects = new List<GameObject>();
        public List<GameObject> Objects { get { return _objects; } }

        private int _last_index = 0;

        public void ForceStart(int size, string prefab, Transform parent_transform)
        {
            for (int ii = 0; ii < size; ++ii)
            {
                GameObject instance = PrefabLoader.Load(prefab);
                instance.SetActive(false);
                instance.transform.parent = parent_transform;
                _objects.Add(instance);
            }
        }
        public void ForceStart(int size, string[] prefabs, Transform parent_transform)
        {
            for (int ii = 0; ii < size; ++ii)
            {
                int rand = UnityEngine.Random.Range(1, 3);
                GameObject instance = PrefabLoader.Load(prefabs[rand]);

                //
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
        private Pool _effect_player_hit_asteroid = new Pool();
        private Pool _effect_level_up = new Pool();

        private GameObject _pooling_parent;

        void Awake()
        {
            //
            _pooling_parent = new GameObject("pooling parent");
            _pooling_parent.transform.parent = transform;

            //  Asteroids.
            //
            _asteroids.ForceStart(GlobalVars.POOL_SIZE_SMALL, new string[]{GlobalVars.PREFAB_NAME_ASTEROID_1,GlobalVars.PREFAB_NAME_ASTEROID_2,GlobalVars.PREFAB_NAME_ASTEROID_3}, 
                _pooling_parent.transform);
            foreach (GameObject ast in _asteroids.Objects)
                Main.GetInstance().Registry.Asteroids.Add(ast);

            //  Bullets.
            //
            _bullets.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_BULLET, _pooling_parent.transform);
            foreach (GameObject b in _bullets.Objects)
                Main.GetInstance().Registry.Bullets.Add(b);

            //  Effects.
            //
            _effect_bullet_hit_asteroid.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_EFFECT_BULLET_HIT_ASTEROID, _pooling_parent.transform);
            foreach (GameObject effect in _effect_bullet_hit_asteroid.Objects)
                Main.GetInstance().Registry.Effects.Add(effect);
            _effect_player_hit_asteroid.ForceStart(GlobalVars.POOL_SIZE_SMALL, GlobalVars.PREFAB_NAME_EFFECT_PLAYER_HIT_ASTEROID, _pooling_parent.transform);
            foreach (GameObject effect in _effect_player_hit_asteroid.Objects)
                Main.GetInstance().Registry.Asteroids.Add(effect);
            //_effect_level_up.ForceStart(GlobalVars.POOL_SIZE_MEDIUM, GlobalVars.PREFAB_NAME_EFFECT_LEVEL_UP, _pooling_parent.transform);
        }

        public GameObject Get_Asteroid() { return _asteroids.Get(); }
        public GameObject Get_Bullet() { return _bullets.Get(); }
        public GameObject Get_Effect_Bullet_Hit_Asteroid() { return _effect_bullet_hit_asteroid.Get(); }
        public GameObject Get_Effect_Player_Hit_Asteroid() { return _effect_player_hit_asteroid.Get(); }
        public GameObject Get_Effect_Level_Up() { return _effect_level_up.Get(); }
    }

}
