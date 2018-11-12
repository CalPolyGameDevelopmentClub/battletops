using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthRPMManager : MonoBehaviour {

    public GameObject player;
    public GameObject rpmMeter;
    public float randomScale = 0.1f;
    public int bars = 1;

	// Use this for initialization
	void Start () {
        int bar = 0;
        float scale = 1.0f;
        rpmMeter.GetComponent<UIHealthRPM>().player = player;
        rpmMeter.GetComponent<UIHealthRPM>().randomScale = randomScale;
        while (bar < bars) {
            rpmMeter.GetComponent<UIHealthRPM>().band = bar * 2;
            GameObject rpmM = Instantiate(rpmMeter, this.transform);
            rpmM.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, 1);
            rpmM.transform.parent = this.transform;

            scale -= 0.05f;
            bar++;
        }
	}

    // Update is called once per frame
    void Update () {
		
	}
}
