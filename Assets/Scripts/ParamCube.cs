using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int band;
    public float startScale, scaleMult;
    public bool useBuffer;
	
	// Update is called once per frame
	void Update () {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeer._freqBand[band] * scaleMult) + startScale, transform.localScale.z);
        }
    }
}
