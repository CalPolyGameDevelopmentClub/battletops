using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Gun", menuName = "ScriptableObjects/Gun", order = 1)]
public class ScriptableGun : ScriptableObject {
    public string objectName = "New ScriptableGun";

    public float FireRate;
    public float Cost = 0.0f;
    public float Jumpforce;
    public ForceMode JumpforceType = ForceMode.Impulse;
    public Vector3[] bulletDir;
    public Vector3[] bulletPos;
    public Color color;
    public GameObject BulletPrefab;

    //public Vector3[] spawnDirs;
}