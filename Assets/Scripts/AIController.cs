﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

    public AGun[] guns;    

	// Use this for initialization
	void Start () {
		
	}    

    // Update is called once per frame
    void Update () {
		foreach (AGun gun in guns) {
            gun.UpdateCD();
        }
	}
}
