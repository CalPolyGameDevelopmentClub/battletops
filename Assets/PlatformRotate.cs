using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour {
    public int curIdx;
    public static Vector2[] positions;
    public int curY;
    public int deltY;

	// Use this for initialization
	void Start () {
        positions = new Vector2[4];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
