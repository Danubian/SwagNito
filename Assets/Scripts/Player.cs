using UnityEngine;
using System.Collections;

public class Player : SwagObject {
	public float horizontalSpeed;
	public RectTransform bounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveLeft()
	{
		if(this.transform.position.x < bounds.rect.xMin)
		{
			Move(-1 * horizontalSpeed);
		}
	}

	public void MoveRight()
	{
		Move(horizontalSpeed);
	}

	private void Move(float speed)
	{
		Vector3 pos = this.transform.position;
		float newPosX = pos.x + speed;
		this.transform.position = new Vector3(newPosX, pos.y, pos.z);
	}
}
