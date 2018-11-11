using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void FixedUpdate() {
        Debug.Log("DebugScript::Update -- Controller 1 test - Horizontal: " + Input.GetAxis("1Vertical"));
        Debug.Log("DebugScript::Update -- Controller 1 test - Trig2: " + Input.GetAxis("2triggerL"));
        Debug.Log("DebugScript::Update -- Controller 1 test - Bump2: " + Input.GetAxis("2bumperR"));
    }

    // Update is called once per frame
    void Update () {
        
	}
}
