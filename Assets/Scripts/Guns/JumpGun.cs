using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGun : AGun {

    public GameObject fireLoc;

    public float initJumpForce = 0.5f;

    public float jumpForce = 0.1f;
    public float fireRate = 1.0f;
    public Vector3 jumpDir = new Vector3(0.0f, 1.0f, 0.0f);

    private float fireTime = 0.0f;
    private bool inAir = false;

    // Ammo
    public int ammoMAX = 10;
    public float notFiringCD = 5.0f;
    public float reloadCD = 1.0f;
    private int ammo;
    private float notFiringTime = 0.0f;
    private float reloadTime = 0.0f;

    //bullet stuff
    public GameObject bulletPrefab;
    public float spawnDist = 1f;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        ammo = ammoMAX;
        rb = fireLoc.GetComponent<Rigidbody>();
	}

    override
    public bool CanFire() {
        return ammo > 0;
    }
    override
    public void Fire() {
        if (!inAir)
            JumpUp();
        else if (fireRate == fireTime) {           
            FireBullet();           
        }
    }
    override
    public void UpdateCD() {
        inAir = fireLoc.transform.position.y > 1f;
        Timers();
        UpdateAmmo();
    }

    private void FireBullet()
    {
        GameObject.Instantiate(
                bulletPrefab,
                fireLoc.transform.position - (fireLoc.transform.up * spawnDist),
                fireLoc.transform.rotation
            );
        rb.AddRelativeForce(jumpDir * jumpForce, ForceMode.Impulse);

        --ammo;
        fireTime = 0.0f;
        notFiringTime = 0.0f;
        reloadTime = 0.0f;
    }

    private void JumpUp()
    {
        rb.AddRelativeForce(jumpDir * initJumpForce, ForceMode.Impulse);
        fireTime = 0.0f;        
        
    }

    private void Timers()
    {
        fireTime = fireTime < fireRate ? fireTime + Time.deltaTime : fireRate;
        notFiringTime = notFiringTime < notFiringCD ? notFiringTime + Time.deltaTime : notFiringCD;
        reloadTime = reloadTime < reloadCD ? reloadTime + Time.deltaTime : reloadCD;
    }

    private void UpdateAmmo() {
        if (reloadTime == reloadCD) {
            ammo = ammo < ammoMAX ? ammo + 1 : ammoMAX;
            reloadTime = 0.0f;
        }
    }
}
