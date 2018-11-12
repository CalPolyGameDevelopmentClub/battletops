using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletForce = 0;
    public int behaviorSel = 0;
    public bool randomness = false;
    public bool dieOnImpact = false;
    public float damageAmount;

    // Use this for initialization
    void Start () {
        Vector3 bulletDir;

        switch (behaviorSel) {
            case 0: default: bulletDir = -1.0f * transform.forward; break;

            case 1: bulletDir = -1.0f * transform.up; break;
        }

        if (randomness) {
            // TODO: !confused atm!
            //this.transform.Rotate(Random.Range(-10, 10), 0 , Random.Range(-10, 10));
        }
        
        GetComponent<Rigidbody>().AddForce(bulletDir * bulletForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (dieOnImpact)
        {
            DealDamage(collision, damageAmount);
            Destroy(gameObject);
        }
    }

    private void DealDamage(Collision collision, float damage)
    {
        Health otherHP = collision.gameObject.GetComponent<Health>();

        if (otherHP)
        {
            otherHP.Damage(damageAmount);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
