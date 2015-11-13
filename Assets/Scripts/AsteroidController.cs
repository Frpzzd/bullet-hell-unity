using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidController : MonoBehaviour
{
	public float tumble;
	public float speed;

	void Start()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
		_rigidbody.velocity = new Vector3(0.0f, 0.0f, speed);
	}

	private Rigidbody _rigidbody;
}
