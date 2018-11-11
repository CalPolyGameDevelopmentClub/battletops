﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public string fireButton;
    public float fireForce;
    public float coolDown = 0.2f;

    //bullet stuff
    public GameObject bulletPrefab;
    public float spawnDist;
    public float bulletForce;

    private float coolTime = 0.0f;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponentInParent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        if (Input.GetAxis(fireButton) > 0.0f && coolDown == coolTime)
        {
            FireBullet();
        }
    }

    public void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(
                bulletPrefab,
                transform.position - (transform.parent.forward * spawnDist),
                transform.parent.rotation
            );

        bullet.GetComponent<Rigidbody>().AddForce(-1.0f * transform.forward * bulletForce, ForceMode.Impulse);

        rb.AddForceAtPosition(transform.parent.forward * fireForce, transform.position, ForceMode.Impulse);
        coolTime = 0.0f;
    }

    // Update is called once per frame
    void Update () {
        //Keep time consitent
        coolTime = coolTime < coolDown ? coolTime + Time.deltaTime : coolDown;
    }
}
