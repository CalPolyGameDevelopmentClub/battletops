using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationClamp : MonoBehaviour
{
    public float clampDegrees;
    public bool clampX, clampY, clampZ;
    private float clampRadians;

    private void OnEnable()
    {
        clampRadians = Mathf.Deg2Rad * clampDegrees;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(
                clampX ? Mathf.Clamp(transform.rotation.eulerAngles.x, -clampRadians, clampRadians) : transform.rotation.eulerAngles.y,
                clampY ? Mathf.Clamp(transform.rotation.eulerAngles.y, -clampRadians, clampRadians) : transform.rotation.eulerAngles.y,
                clampZ ? Mathf.Clamp(transform.rotation.eulerAngles.z, -clampRadians, clampRadians) : transform.rotation.eulerAngles.y
            );
    }
}
