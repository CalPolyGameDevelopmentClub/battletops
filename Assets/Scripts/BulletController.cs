using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletForce = 0;
    public int behaviorSel = 0;
    public bool randomness = false;
    public bool dieOnImpact = false;
    public float damageAmount;
    public Vector3 shootDir = new Vector3(0f, 0f, 1f);

    // Use this for initialization
    void Start () {
        

        if (randomness) {
            // TODO: !confused atm!
            this.transform.Rotate(Random.Range(-10, 10), 0 , Random.Range(-10, 10));
        }
        
        GetComponent<Rigidbody>().AddRelativeForce(shootDir * bulletForce, ForceMode.Impulse);
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
}
