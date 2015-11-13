using UnityEngine;
using System.Collections;

public class MoveSpawner : MonoBehaviour
{
	public Boundary boundary;
	public float Speed = 10f;
	// Use this for initialization
	void Start ()
	{
		_startPoint = transform.position;
		_startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (transform.position.x > boundary.xMax)
		{
			Speed = -Speed;
			_startPoint.x = boundary.xMax;
			_startTime = Time.time;
		}

		if (transform.position.x < boundary.xMin)
		{
			Speed = -Speed;
			_startPoint.x = boundary.xMin;
			_startTime = Time.time;
			
		}

		transform.position = new Vector3(_startPoint.x + ((Time.time - _startTime) * Speed), _startPoint.y, _startPoint.z);
	}
	
	private Vector3 _startPoint;
	private float _startTime;
}
