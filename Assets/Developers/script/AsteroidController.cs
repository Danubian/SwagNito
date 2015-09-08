using UnityEngine;
using System.Collections;

namespace Developers
{

    public class AsteroidController : MonoBehaviour
    {
        public ColumnController colControl;
        // Use this for initialization
        void Start()
        {
            SpawnAsteroid(GlobalVars.COLUMNS_CENTER_INDEX);
        }
		
		private float lastSpawnTime;
        void Update()
        {
			if ((Time.time - lastSpawnTime) >= GlobalVars.ASTEROID_SPAWN_TIME)
            {
                int index = Random.Range(0, GlobalVars.COLUMNS_TOTAL);
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
