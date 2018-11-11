using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float jumpForce = 0.1f;
    public float coolDown = 1.0f;
    public Vector3 jumpDir = new Vector3(0.0f, 1.0f, 0.0f);
    public float shotDelay = 0.05f;

    private float coolTime = 1.0f;
    private float airTime = 0.0f;
    private float shotTime = 0.0f;
    private bool hasFired = false;

    //bullet stuff
    public GameObject bulletPrefab;
    public float spawnDist;
    public float bulletForce;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    //FixedUpdate for physics
    void FixedUpdate()
    {
        //if player presses space, jump with shotgun
        if (Input.GetAxis("Jump") > 0.0f && coolDown == coolTime)
        {
            JumpUp();
            
        }
        if (hasFired && shotTime >= shotDelay)
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(
                bulletPrefab,
                transform.position - (transform.up * spawnDist),
                transform.rotation
            );

        bullet.GetComponent<Rigidbody>().AddForce(-1.0f * transform.up * bulletForce, ForceMode.Impulse);

        hasFired = false;
    }

    public void JumpUp()
    {
        rb.AddRelativeForce(jumpDir * jumpForce, ForceMode.Impulse);
        coolTime = 0.0f;
        hasFired = true;
    }

    public void Timers()
    {
        coolTime = coolTime < coolDown ? coolTime + Time.deltaTime : coolDown;
        airTime = transform.position.y > 0.5f ? airTime + Time.deltaTime : 0.0f;
        shotTime = hasFired ? shotTime + Time.deltaTime : 0.0f;
    }

    // Update is called once per frame
    void Update () {
        //Keep time consitent
        Timers();
    }
}
