using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardGun : AGun {

    public GameObject fireLoc;
    //public string fireButton;
    public float fireForce = 2.0f;
    public float fireRate = 0.1f;

    //bullet stuff
    public GameObject bulletPrefab;
    public float spawnDist = 1.0f;

    // Ammo
    public int ammoMAX = 10;
    public float notFiringCD = 5.0f;
    public float reloadCD = 1.0f;
    private int ammo;
    private float notFiringTime = 0.0f;
    private float reloadTime = 0.0f;

    private float fireTime = 0.0f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        ammo = ammoMAX;
        rb = fireLoc.GetComponentInParent<Rigidbody>();
	}

    override
    public bool CanFire() {
        return ammo > 0;
    }
    override
    public void Fire() {
        if (fireTime == fireRate)
            FireBullet();
    }
    override
    public void UpdateCD() {
        Timers();
        UpdateAmmo();
    }

    private void FireBullet()
    {
        GameObject.Instantiate(
                bulletPrefab,
                fireLoc.transform.position - (fireLoc.transform.parent.forward * spawnDist),
                fireLoc.transform.parent.rotation
            );

        rb.AddForceAtPosition(fireLoc.transform.parent.forward * fireForce, fireLoc.transform.position, ForceMode.Impulse);

        --ammo;
        fireTime = 0.0f;
        notFiringTime = 0.0f;
        reloadTime = 0.0f;
    }

    private void Timers() {
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
