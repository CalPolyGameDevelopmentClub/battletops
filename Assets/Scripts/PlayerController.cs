using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject[] holsters;
    public int holsterToReplace;
    private AGun[] guns;
    private AGun jumpGun;
    private bool inAir = false;
    private float baseY;
    private float initJumpForce = 1.0f;

    // Controls:
    public string fire;
    public string jump;
    public string spin;

    public string horizMove;
    public string vertMove;
    public int playerNum = 1;

    public GameObject player;

    public float accelSpeed = 5.0f;
    private float maxMag = 1.0f;
    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        //Controls
        fire = playerNum + fire;
        jump = playerNum + jump;
        spin = playerNum + spin;
        horizMove = playerNum + horizMove;
        vertMove = playerNum + vertMove;

        //Init
        guns = new AGun[holsters.Length - 1];
        for (int h = 0; h < holsters.Length - 1; h++) {
            guns[h] = holsters[h].GetComponent<AGun>();
        }
        jumpGun = holsters[holsters.Length - 1].GetComponent<AGun>();
        holsterToReplace = 0;

        rb = GetComponent<Rigidbody>();
        baseY = transform.position.y;
	}

    private void FixedUpdate() {
        //Fire: 
        if (Input.GetAxis(fire) > 0.1f) {
            foreach (AGun gun in guns) {                
                if (gun.CanFire()) {
                    gun.Fire();
                }
            }
        }
        //Jump:
        if (Input.GetAxis(jump) > 0.1f) {
            if (!inAir) {
                Debug.Log("JUMP!");
                rb.AddRelativeForce(transform.up * initJumpForce, ForceMode.Impulse);
                inAir = true;
            }               
            else if (jumpGun.CanFire())
                jumpGun.Fire();
        }
        //Spin
        if (Input.GetAxis(spin) > 0.1f)
            player.GetComponent<Health>().Damage(-0.5f);

        //Move: 
        float x = Input.GetAxis(horizMove);
        float z = Input.GetAxis(vertMove);

        rb.AddForce((new Vector3(x, 0, z)) * accelSpeed * maxMag, ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update () {
        //Update guns
		foreach (AGun gun in guns) {
            gun.UpdateCD();
        }
        jumpGun.UpdateCD();

        float dist = 1.0f;
        RaycastHit hit;
        Vector3 dir = new Vector3(0, -1, 0);
        //edit: to draw ray also//
        Debug.DrawRay(transform.position, dir * dist, Color.green);
        //end edit//
        if (Physics.Raycast(transform.position, dir, out hit, dist)) {
            inAir = false;
        } else {
            //Should never happen!!
            inAir = true;
        }

        // Update movement
        maxMag = Mathf.Sqrt(player.GetComponent<Health>().currentHP / 10.0f) + 1.5f;

        Debug.Log("test: " + maxMag);

        Vector2 normVec2 = new Vector2(rb.velocity.x, rb.velocity.z);
        float mag = normVec2.magnitude;
        normVec2.Normalize();
        normVec2 = normVec2 * maxMag;
        rb.velocity = mag > maxMag ? new Vector3(normVec2.x, rb.velocity.y, normVec2.y) : rb.velocity;
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pickup")
        {
            PickupHolder ph = collision.gameObject.GetComponent<PickupHolder>();
            attachNewGuns(ph.item, ph.type);
        }
    }

    private void attachNewGuns(ScriptableGun scrGun, int type=0) {
        switch(type) {
            case 0:
                holsters[holsterToReplace].GetComponent<GunController>().gun = scrGun;
                holsterToReplace = (holsterToReplace + 1) % holsters.Length;
                break;

            default: break;
        }
    }
}
