using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AGun[] guns;
    public string[] gunTrigger;

    // Use this for initialization
    void Start () {
		
	}

    private void FixedUpdate() {
        int trig = 0;
        foreach (AGun gun in guns) {
            if (Input.GetAxis(gunTrigger[trig]) > 0.0f && gun.CanFire()) {
                gun.Fire();
            }
            ++trig;
        }
    }

    // Update is called once per frame
    void Update () {
		foreach (AGun gun in guns) {
            gun.UpdateCD();
        }
	}
}
