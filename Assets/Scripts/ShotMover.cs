using UnityEngine;
using System.Collections;

public class ShotMover : MonoBehaviour
{

    public float speed;
    public Rigidbody shot;
    void Start()
    {
        shot.velocity = transform.forward * speed;
    }


}
