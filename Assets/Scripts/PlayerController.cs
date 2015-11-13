using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float tilt;
    public Boundary boundary;

    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;

    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }



    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //TODO: make this more efficient.
        var go = GameObject.FindGameObjectsWithTag("Boost");
        var thruster = GameObject.FindGameObjectWithTag("Thrust").GetComponent<ParticleSystem>();

        if (moveVertical >= 0f && !thruster.isPlaying)
        {
            thruster.Play();
        }
        

        if (moveVertical > 0f)
        {
            foreach (var obj in go)
            {
                var p = obj.GetComponent<ParticleSystem>();
                p.Play();
            }
        }
        else
        {
            foreach (var obj in go)
            {
                var p = obj.GetComponent<ParticleSystem>();
                p.Stop();
            }

            if(moveVertical < 0f)
            {
                thruster.Stop();
            }
           
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rigidbody.velocity = movement * speed;

        _rigidbody.position = new Vector3
        (
            Mathf.Clamp(_rigidbody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(_rigidbody.position.z, boundary.zMin, boundary.zMax)
        );

        _rigidbody.rotation = Quaternion.Euler(270.0f + (_rigidbody.velocity.x * -tilt), 270.0f, 0.0f);
    }
}
