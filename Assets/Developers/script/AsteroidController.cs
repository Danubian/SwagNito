using UnityEngine;
using System.Collections;

namespace Developers
{
    public class AsteroidController : MonoBehaviour
    {
        public ColumnController colControl;

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

        private bool bSpeedAmpViaTime_rise = true;
        private float speedAmpViaTime = 0;
		private float asteroidSpeed = GlobalVars.ASTEROID_SPEED;
        private void SpawnAsteroid(int index)
        {
            lastSpawnTime = Time.time;

            //
            if (speedAmpViaTime >= .4f)
                bSpeedAmpViaTime_rise = false;
            else if(speedAmpViaTime <= -.4f)
                bSpeedAmpViaTime_rise=true;

            //
            if (bSpeedAmpViaTime_rise == true)
                speedAmpViaTime += Time.deltaTime;
            else
                speedAmpViaTime -= Time.deltaTime;

            //
            asteroidSpeed = GlobalVars.ASTEROID_SPEED + Mathf.Sin(speedAmpViaTime) * GlobalVars.ASTEROID_SPEED_RAMP;


            GameObject asteroid = Main.GetInstance().Pools.Get_Asteroid();
            if( asteroid != null )
            {
                Asteroid asteroidController = asteroid.GetComponent<Asteroid>();
                asteroidController.colControl = colControl;
				asteroidController.Setup(index, asteroidSpeed);
				
				//
                Main.GetInstance().Audio.PlayMusic_SpawnAsteroid();
            }
        }
    }
}
