using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    public float jumpForce = 0.1f;
    public float coolDown = 1.0f;
    public Vector3 jumpDir = new Vector3(0.0f, 1.0f, 0.0f);

    private float coolTime = 1.0f;


    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    //FixedUpdate for physics
    void FixedUpdate()
    {
        //if player presses space, jump with shotgun
        if (Input.GetAxis("Jump") > 0.0f && coolDown == coolTime)
        {
            rb.AddRelativeForce(jumpDir * jumpForce, ForceMode.Impulse);
            coolTime = 0.0f;
        }
    }

    // Update is called once per frame
    void Update () {
        //Keep time consitent
        coolTime = coolTime < coolDown ? coolTime + Time.deltaTime : coolDown;
    }
}
