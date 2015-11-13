using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{


	public GameObject Explosion;
	public GameObject PlayerExplosion;
	public int ScoreValue;
	

	void Start()
	{
		GameObject gameControllerObj = GameObject.FindWithTag("GameController");
		if (gameControllerObj != null)
		{
			_controller = gameControllerObj.GetComponent<GameController>();
		}

		if (_controller == null)
		{
			Debug.Log("Cannot find game controller script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		Instantiate(Explosion, transform.position, transform.rotation);
		_controller.AddScore(ScoreValue);

		if (other.tag == "Player")
		{
			Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
			_controller.GameOver();
		}

		Destroy(other.gameObject);
		Destroy(gameObject);
	}

	private GameController _controller;
}
