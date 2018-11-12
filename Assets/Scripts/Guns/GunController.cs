using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : AGun {

    public ScriptableGun gun;
    public GameObject player;
    public bool isJumpGun = false;

    private Health pHealth;
    private int leeway = 5;
    private static float SPWNDIS = 1.0f;

    private float fireTime;
    private float fireRate;


    public override bool CanFire() {
        return pHealth.currentHP >= gun.Cost * leeway && fireTime == fireRate;
    }

    public override void Fire() {
        FireBullet();
        pHealth.Damage(gun.Cost);
    }

    public override void UpdateCD() {
        Timers();
    }

    // Use this for initialization
    void Start () {
        pHealth = player.GetComponent<Health>();

        fireTime = 0.0f;
        fireRate = gun.FireRate;
	}

    private void FireBullet() {
        Vector3 pos;

        //if (isJumpGun)
        //    pos = transform.position - (transform.up * SPWNDIS);
        //else
        pos = transform.position + (transform.forward * SPWNDIS);

        GameObject.Instantiate(gun.BulletPrefab, pos, transform.rotation);

        //working
        if (isJumpGun)
            player.GetComponent<Rigidbody>().AddRelativeForce(player.transform.up * gun.Jumpforce, gun.JumpforceType);

        fireTime = 0.0f;        
    }

    private void Timers() {
        fireTime = fireTime < fireRate ? fireTime + Time.deltaTime : fireRate;        
    }
}
