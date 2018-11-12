using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int band;
    public float startScale, scaleMult;
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[band] * scaleMult) + startScale, transform.localScale.z);
	}
}
