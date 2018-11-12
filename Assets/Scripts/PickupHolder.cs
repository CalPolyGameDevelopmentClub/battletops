using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHolder : MonoBehaviour {

    public ScriptableGun item;
    public int type = 0;

    private void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        //mr.material.shader = Shader.Find("_Color");
        //mr.material.SetColor("_Color", item.color);
        mr.material.color = item.color; 

        Light l = gameObject.GetComponentInChildren<Light>();
        l.color = item.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
