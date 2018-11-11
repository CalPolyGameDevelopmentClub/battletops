using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour {

    public enum Type { FORWARD, JUMP };

    public abstract bool CanFire();
    public abstract void Fire();
    public abstract void UpdateCD();
}


