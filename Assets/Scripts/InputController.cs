using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	public Player player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLeftClick()
	{
		Debug.Log("Left Side Clicked");
		if(player != null)
		{
			player.MoveLeft();
		}
	}

	public void OnRightClick()
	{
		Debug.Log("Right Side Clicked");
		if(player != null)
		{
			player.MoveRight();
		}
	}
}
