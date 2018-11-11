using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinStart : MonoBehaviour {

    public float startForce;
    private Rigidbody rb;
   
	// Use this for initialization
	void Start () {
        Vector3 dir = Vector3.Normalize(new Vector3(Random.value, 0.0f, Random.value));
        rb = GetComponent<Rigidbody>();

        rb.AddRelativeForce(dir * startForce, ForceMode.Impulse);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
