using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour 
{
	
	public float Speed;

	void Start()
	{
		_startPoint = transform.position;
		_startTime = Time.time;
		_endPoint = transform.position.y - 15f;
	}

	void Update () 
	{
		transform.position = new Vector3 (_startPoint.x, _startPoint.y - ((Time.time - _startTime) * Speed), _startPoint.z);

		if (transform.position.y < _endPoint)
		{
			transform.position = _startPoint;
			_startTime = Time.time;
		}
	}

	private Vector3 _startPoint;
	private float _endPoint;
	private float _startTime;
}
