using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    public float bulletForce = 0;
    public int behaviorSel = 0;

    // Use this for initialization
    void Start () {
        switch(behaviorSel) {
            case 0: default: GetComponent<Rigidbody>().AddForce(-1.0f * transform.forward * bulletForce, ForceMode.Impulse); break;

            case 1: GetComponent<Rigidbody>().AddForce(-1.0f * transform.up * bulletForce, ForceMode.Impulse); break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
