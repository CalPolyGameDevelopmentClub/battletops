using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    public GameObject[] pickups;
    public float spawnInterval;
    public float spawnDistance;
    
    [SerializeField]
    private float spawnTime = 0.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnInterval)
        {
            spawnTime = 0.0f;
            GameObject.Instantiate(
                    pickups[Random.Range(0, pickups.Length)],
                    transform.position + new Vector3(Random.Range(-spawnDistance, spawnDistance), 9.0f, Random.Range(-spawnDistance, spawnDistance)),
                    Quaternion.identity
                );
        }
	}
}
