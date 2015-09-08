using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
	public Player player;

	// Use this for initialization
	void Start () {
        Canvas canv1 = gameObject.GetComponent<Canvas>();
        canv1.worldCamera = Camera.main;
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
