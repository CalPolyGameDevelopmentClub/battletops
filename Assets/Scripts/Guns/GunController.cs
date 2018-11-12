using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : AGun {

    public ScriptableGun gun;
    public GameObject player;
    public bool isJumpGun = false;

    private Health pHealth;
    private int leeway = 5;
    private static float SPWNDIS = 0.25f;

    private float fireTime;


    public override bool CanFire() {
        return gun != null && pHealth.currentHP >= gun.Cost * leeway && fireTime == gun.FireRate;
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
	}

    private void FireBullet() {
        Vector3 pos;
        Quaternion dir;

        for (int i = 0; i < gun.bulletPos.Length; i++)
        {
            dir = transform.rotation * Quaternion.Euler(gun.bulletDir[i]);
            pos = (transform.rotation * gun.bulletPos[i]) + transform.position + (transform.forward * SPWNDIS);
            GameObject.Instantiate(gun.BulletPrefab, pos, dir);
        }

        //working
        if (isJumpGun)
            player.GetComponent<Rigidbody>().AddRelativeForce(player.transform.up * gun.Jumpforce, gun.JumpforceType);

        fireTime = 0.0f;        
    }

    private void Timers() {
        if (gun != null)
            fireTime = fireTime < gun.FireRate ? fireTime + Time.deltaTime : gun.FireRate;        
    }
}
