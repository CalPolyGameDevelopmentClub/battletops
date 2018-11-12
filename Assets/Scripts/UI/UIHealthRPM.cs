using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthRPM : MonoBehaviour {

    public GameObject player;
    private Health pHealth;
    public Color color;
    private float curH;
    public float randomScale = 0.1f;
    private float randMin, randMax;
    private float randomness;

    public Image _meter;

	// Use this for initialization
	void Start () {
        pHealth = player.GetComponent<Health>();
        curH = pHealth.currentHP;      
        randomness = 0f;
        randMin = -0.5f * randomScale;
        randMax = 0.5f * randomScale;
	}

    private void FixedUpdate() {
        if (color != player.GetComponentInChildren<Light>().color) {
            color = player.GetComponentInChildren<Light>().color;            
        }
        color.a = Mathf.Clamp01(1.0f - Random.Range(0.0f, 0.2f));

        randomness = Random.Range(randMin, randMax);
        _meter.color = color;
    }

    // Update is called once per frame
    void Update () {
        curH = pHealth.currentHP;
        float fill = 0.5f * curH / pHealth.maxHP;
        _meter.fillAmount = fill + randomness;
	}
}
