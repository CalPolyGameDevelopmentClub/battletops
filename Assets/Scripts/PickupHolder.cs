using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHolder : MonoBehaviour {

    public GameObject item;
    public AGun.Type type;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
