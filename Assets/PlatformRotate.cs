using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour {
    public int curIdx;
    public static Vector2[] positions;
    public int curY;
    public int deltY;

    public float minH;
    public float maxH;
    public float speed;

    private float toggle = 1.0f;

	// Use this for initialization
	void Start () {
        positions = new Vector2[4];
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Translate(new Vector3(0.0f, toggle * speed, 0.0f));

        if (transform.position.y <= minH)
        {
            toggle = 1.0f;
        }
        if (transform.position.y >= maxH)
        {
            toggle = -1.0f;
        }
	}
}
