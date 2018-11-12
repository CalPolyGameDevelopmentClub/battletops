using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int maxLives;
    public int currentLives;
    public float maxHP;
    public float currentHP;

    public Slider healthSlider;
    public Image damageImage;
    public Image[] stock; // 3 lives for now
    public float flashSpeed = 5f;
    public Color flashCol = new Color(1f, 0f, 0f, 0.1f); // Match to player color

    AudioSource playerAudio;
    public AudioClip damageClip, deathClip;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        currentHP = maxHP;

        GameObject go = GameObject.Find("HUDCanvas");
        if (!go)
            return;
        stock = go.GetComponents<Image>();

        for (int i = 0; i < maxLives; i++)
        {
            stock[i].enabled = true;
        }
    }

    //private void Update()
    //{
    //    if (currentHP < maxHP) { damageImage.color = flashCol; }
    //    else
    //    {
    //        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    //    }
    //}

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

        if (currentLives > maxLives) { stock[maxLives - currentLives].enabled = false; }
        playerAudio.PlayOneShot(deathClip);
        //Particles();

        if (currentLives <= 0) Destroy(gameObject);
    }
}
