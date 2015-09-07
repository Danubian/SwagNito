using UnityEngine;
using System.Collections;

public class ColumnController : MonoBehaviour {
	//	public float horizontalSpeed;
	public RectTransform boundaries;
	//	public float leftBound;
	//	public float rightBound;
	private float basePos;
	//	private float width = 1f;
	public int max = 8; 
	private float colSize;
//	private float length;
	[HideInInspector] public float bottomBound;
	[HideInInspector] public float topBound;

	// Use this for initialization
	void Start () {
		Vector3[] corners = new Vector3[4];
		boundaries.GetWorldCorners(corners);
		foreach(Vector3 corner in corners)
		{
			Debug.Log("Corner : " + corner.ToString());
		}

		float leftBound = corners[0].x;
		bottomBound = corners[0].y;
		float rightBound = corners[2].x;
		topBound = corners[2].y;

		float length = rightBound - leftBound;
		colSize = length/max;
		
		basePos = leftBound + colSize/2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetIndexPos(int index)
	{
		return (colSize * index) + basePos;
	}

	public bool InColumnBounds(int index)
	{
		bool leftBounds = index >= 0;	
		bool rightBounds = index < max;
		return  leftBounds && rightBounds;
	}

	public bool InVertBounds(float pos, float buffer)
	{
		Debug.Log("InVertBounds : " + pos + ", " + buffer);
		bool inBottomBound = pos >= bottomBound - buffer;	
		Debug.Log("inBottomBound : " + inBottomBound + ", " + bottomBound);
		bool inTopBound = pos <= topBound + buffer;
		Debug.Log("inTopBound : " + inTopBound + ", " + topBound);
		return inBottomBound && inTopBound;
	}
}
