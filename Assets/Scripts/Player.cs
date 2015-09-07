using UnityEngine;
using System.Collections;

public class Player : SwagObject {
//	public float horizontalSpeed;
	public RectTransform boundaries;
//	public float leftBound;
//	public float rightBound;
	public float basePos;
//	private float width = 1f;
	public int index;
	public int max; 
	public float chunkSize;
	public float length;
	private bool moveLock = false;

	// Use this for initialization
	void Start () {
		Vector3[] corners = new Vector3[4];
		boundaries.GetWorldCorners(corners);
		float leftBound = corners[0].x;
		float rightBound = corners[2].x;
		length = rightBound - leftBound;
		chunkSize = length/max;

		basePos = leftBound + chunkSize/2;

		SetToIndex(4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveLeft()
	{

//		if(this.transform.position.x - width / 2 - horizontalSpeed > leftBound)
//		{ 
		if(index - 1 >= 0)
		{
			Move(index - 1);
		}
	}

	public void MoveRight()
	{
//		if(this.transform.position.x + width / 2 + horizontalSpeed < rightBound)
//		{
		if(index + 1 < max)
		{
			Move(index + 1);
		}
	}

	private void SetToIndex(int index)
	{
		this.index = index;
		Vector3 startPos = this.transform.position;
		//			float newPosX = startPos.x + speed;
		float newPosX = (chunkSize * index) + basePos;
		
		Vector3 endPos = new Vector3(newPosX, startPos.y, startPos.z);
		this.transform.position = endPos;
	}

	private void Move(int index)
	{
		if(!moveLock)
		{
			this.index = index;
			Vector3 startPos = this.transform.position;
//			float newPosX = startPos.x + speed;
			float newPosX = (chunkSize * index) + basePos;

			Vector3 endPos = new Vector3(newPosX, startPos.y, startPos.z);
			StartCoroutine(MoveToPosition(startPos, endPos, .125f));
		}
//		this.transform.position = Vector3.Lerp(startPos, endPos, 1);
//		this.transform.position = new Vector3(newPosX, pos.y, pos.z);
	}

	private IEnumerator MoveToPosition(Vector3 startPos, Vector3 endPos, float time)
	{
		moveLock = true;
		float elapsedTime = 0;
		this.transform.position = startPos;
		
		while (elapsedTime < time)
		{
			this.transform.position = Vector3.Lerp(this.transform.position, endPos, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		moveLock = false;
	}

}
