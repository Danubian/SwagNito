using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	public ColumnController colControl;
	// Use this for initialization
	void Start () {
	
		SpawnAsteroid(new Vector3(0f, 0f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void SpawnAsteroid(Vector3 pos)
	{
		GameObject asteroid = Instantiate(Resources.Load("Asteroid")) as GameObject;
		asteroid.transform.parent = transform;
		asteroid.name = "Asteroid";
		Asteroid asteroidController = asteroid.GetComponent<Asteroid>();
		asteroidController.colControl = colControl;
		asteroidController.Move(4);
	}
}
