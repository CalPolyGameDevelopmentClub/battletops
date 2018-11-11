using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : AGun {

    public GameObject fireLoc;

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

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = fireLoc.GetComponent<Rigidbody>();
	}

    override
    public bool CanFire() {
        return coolDown == coolTime;
    }
    override
    public void Fire() {
        JumpUp();
    }
    override
    public void UpdateCD() {
        Timers();

        if (hasFired && shotTime >= shotDelay) {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject.Instantiate(
                bulletPrefab,
                fireLoc.transform.position - (fireLoc.transform.up * spawnDist),
                fireLoc.transform.rotation
            );
        
        hasFired = false;
    }

    private void JumpUp()
    {
        rb.AddRelativeForce(jumpDir * jumpForce, ForceMode.Impulse);
        coolTime = 0.0f;
        hasFired = true;
    }

    private void Timers()
    {
        coolTime = coolTime < coolDown ? coolTime + Time.deltaTime : coolDown;
        airTime = fireLoc.transform.position.y > 0.5f ? airTime + Time.deltaTime : 0.0f;
        shotTime = hasFired ? shotTime + Time.deltaTime : 0.0f;
    }

}
