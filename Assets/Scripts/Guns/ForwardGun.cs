using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardGun : AGun {

    public GameObject fireLoc;
    //public string fireButton;
    public float fireForce = 2.0f;
    public float coolDown = 0.1f;

    //bullet stuff
    public GameObject bulletPrefab;
    public float spawnDist = 1.0f;    

    private float coolTime = 0.0f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = fireLoc.GetComponentInParent<Rigidbody>();
	}

    override
    public bool CanFire() {
        return coolDown == coolTime;
    }
    override
    public void Fire() {
        FireBullet();
    }
    override
    public void UpdateCD() {
        coolTime = coolTime < coolDown ? coolTime + Time.deltaTime : coolDown;
    }

    private void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(
                bulletPrefab,
                fireLoc.transform.position - (fireLoc.transform.parent.forward * spawnDist),
                fireLoc.transform.parent.rotation
            );

        rb.AddForceAtPosition(fireLoc.transform.parent.forward * fireForce, fireLoc.transform.position, ForceMode.Impulse);
        coolTime = 0.0f;
    }
}
