using UnityEngine;
using System.Collections;

public class ColumnController : MonoBehaviour {
	//	public float horizontalSpeed;
	public RectTransform boundaries;
	//	public float leftBound;
	//	public float rightBound;
	public float basePos;
	//	private float width = 1f;
	public int max = 8; 
	public float chunkSize;
	public float length;

	// Use this for initialization
	void Start () {
		Vector3[] corners = new Vector3[4];
		boundaries.GetWorldCorners(corners);
		float leftBound = corners[0].x;
		float rightBound = corners[2].x;
		length = rightBound - leftBound;
		chunkSize = length/max;
		
		basePos = leftBound + chunkSize/2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetIndexPos(int index)
	{
		return (chunkSize * index) + basePos;
	}

	public bool InBounds(int index)
	{
		bool leftBounds = index >= 0;	
		bool rightBounds = index < max;
		return  leftBounds && rightBounds;
	}
}
