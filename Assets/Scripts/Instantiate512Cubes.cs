using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Cubes : MonoBehaviour {
    public GameObject sampleCubePrefab_b;
    public GameObject sampleCubePrefab_p;
    
    GameObject[] sampleCube = new GameObject[512];
    public float maxScale;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 512; i++)
        {
            GameObject instanceSampleCube;
            if (i % 2 == 0) { instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab_b); }
            else            { instanceSampleCube = (GameObject)Instantiate(sampleCubePrefab_p); }
            instanceSampleCube.transform.position = this.transform.position;
            instanceSampleCube.transform.parent = this.transform;
            instanceSampleCube.name = "SampleCube" + i;

            // Circle of cubes for test (360 / 512 = 0.073125)
            this.transform.eulerAngles = new Vector3(0, -0.703125f * i, 0);
            instanceSampleCube.transform.position = Vector3.forward * 70;
            sampleCube[i] = instanceSampleCube;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < 512; i++)
        {
            if (sampleCube != null)
            {
                sampleCube[i].transform.localScale = new Vector3(10, (AudioPeer._samples[i] * maxScale) + 2, 10);
            }
        }
	}
}
