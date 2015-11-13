using UnityEngine;
using System.Collections;

public class DestroyerScript : MonoBehaviour
{
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}
