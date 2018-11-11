using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public AGun[] guns;
    public string[] gunTriggers;
    public string playerNum = "1";

    public GameObject forwardGunR;
    public GameObject forwardGunL;
    public GameObject jumpGun;

    public GameObject gunSwitch;


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

        if (Input.GetAxis("TFire1") > 0.0f) {
            attachNewGuns(gunSwitch, AGun.Type.FORWARD);
        }

    }

    // Update is called once per frame
    void Update () {
		foreach (AGun gun in guns) {
            gun.UpdateCD();
        }

        
	}

    private void attachNewGuns(GameObject prefab, AGun.Type type=AGun.Type.FORWARD) {
        switch(type) {
            case AGun.Type.FORWARD:
                Destroy(guns[0].gameObject, 0.2f);
                Destroy(guns[1].gameObject, 0.2f);

                prefab.GetComponent<ForwardGun>().fireLoc = forwardGunL;
                GameObject gunF = Instantiate(prefab, this.gameObject.transform);
                guns[0] = gunF.GetComponent<AGun>();

                prefab.GetComponent<ForwardGun>().fireLoc = forwardGunR;
                gunF = Instantiate(prefab, this.gameObject.transform);
                guns[1] = gunF.GetComponent<AGun>();

                break;

            case AGun.Type.JUMP:
                Destroy(guns[2].gameObject, 0.2f);

                prefab.GetComponent<JumpGun>().fireLoc = this.gameObject;
                GameObject gunJ = Instantiate(prefab, this.gameObject.transform);
                guns[2] = gunJ.GetComponent<AGun>();

                break;

            default: break;
        }
    }

}
