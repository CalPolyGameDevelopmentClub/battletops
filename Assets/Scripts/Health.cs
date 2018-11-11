using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxLives;
    public int currentLives;
    public float maxHP;
    public float currentHP;

    public void Damage(float damage)
    {
        currentHP -= damage;

        if (currentHP <= 0.0f)
        {
            Death();
        }
    }

    private void Death()
    {
        //Respawn();

        currentLives--;
        currentHP = maxHP;

        //Particles();

        if (currentLives <= 0) Destroy(gameObject);
    }
}
