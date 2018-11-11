using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTime : MonoBehaviour {

    public float lifespan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        lifespan -= Time.deltaTime;

        if (lifespan <= 0.0f)
        {
            Destroy(gameObject);
        }
	}
}
