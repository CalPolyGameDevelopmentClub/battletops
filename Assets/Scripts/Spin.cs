using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {
    public float spin;
    public float bobSpeed;
    private float fraction;
    private Vector3 start;
    private Vector3 end;

    // Use this for initialization
    void Start () {
        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        end = new Vector3(transform.position.x, 10f, transform.position.z);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.Rotate(new Vector3(0, spin, 0));
        fraction += Time.deltaTime * bobSpeed;
        this.transform.position = Vector3.Lerp(start, end, fraction);
	}
}
