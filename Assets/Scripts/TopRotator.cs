using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopRotator : MonoBehaviour {

    public GameObject player;
    private Health pHealth;
    private float spin;

	// Use this for initialization
	void Start () {
        pHealth = player.GetComponent<Health>();
        spin = pHealth.currentHP;
	}

    private void FixedUpdate() {
        transform.Rotate(new Vector3(0, spin, 0));
    }

    // Update is called once per frame
    void Update () {
        spin = pHealth.currentHP / 10.0f;
    }
}
