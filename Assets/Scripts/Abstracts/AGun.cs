using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour {

    public abstract bool CanFire();
    public abstract void Fire();
    public abstract void UpdateCD();
}
