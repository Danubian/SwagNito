using UnityEngine;
using System.Collections;

namespace Developers
{

    public class AsteroidController : MonoBehaviour
    {
        public ColumnController colControl;
        private static string ASTEROID_PATH = "Asteroid";
        private static float SPAWN_TIME = 1f;
        private float lastSpawnTime = 0f;
        // Use this for initialization
        void Start()
        {
            SpawnAsteroid(4);
        }

        // Update is called once per frame
        void Update()
        {
            if ((Time.time - lastSpawnTime) >= SPAWN_TIME)
            {
                int index = Random.Range(0, colControl.max);
                SpawnAsteroid(index);
            }
        }

        private void SpawnAsteroid(int index)
        {
            lastSpawnTime = Time.time;

            GameObject asteroid = Main.GetInstance().Pools.Get_Asteroid();
            if( asteroid != null )
            {
                Asteroid asteroidController = asteroid.GetComponent<Asteroid>();
                asteroidController.colControl = colControl;
                asteroidController.Setup(index);
            }
        }
    }
}
