using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AGun[] guns;
    public string[] gunTriggers;
    public string playerNum = "1";

    // Use this for initialization
    void Start () {
        for (int t = 0; t < gunTriggers.Length; t++) {
            gunTriggers[t] = playerNum + gunTriggers[t];
        }
	}

    private void FixedUpdate() {
        int trig = 0;
        foreach (AGun gun in guns) {
            if (Input.GetAxis(gunTriggers[trig]) > 0.1f && gun.CanFire()) {
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
