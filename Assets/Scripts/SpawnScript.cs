using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{

	public GameObject[] Obj;
	public float SpawnMin = 1f;
	public float SpawnMax = 2f;



	// Use this for initialization
	void Start () {
		Spawn();
	}

	void Spawn()
	{
		Instantiate(Obj[Random.Range(0, Obj.Length)], transform.position, Quaternion.identity);
		Invoke("Spawn", Random.Range(SpawnMin, SpawnMax));
	}
}
