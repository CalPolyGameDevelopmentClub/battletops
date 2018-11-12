using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int maxLives;
    public int currentLives;
    public float maxHP;
    public float currentHP;
    public float startHP;

    public Slider healthSlider;
    public Image damageImage;
    public Image[] stock; // 3 lives for now
    public ParticleSystem deathParticle;
    public float flashSpeed = 5f;
    public Color flashCol = new Color(1f, 0f, 0f, 0.1f); // Match to player color

    public AudioSource playerAudio;
    public AudioClip damageClip, deathClip;

    private void Awake()
    {
        playerAudio = GetComponent<AudioSource>();
        //currentHP = maxHP;

        GameObject go = GameObject.Find("HUDCanvas");
        if (!go)
            return;
        stock = go.GetComponents<Image>();

        for (int i = 0; i < maxLives; i++)
        {
            stock[i].enabled = true;
        }
        
    }

    private void Start() {
        startHP = currentHP;
    }

    private void Update()
    {
        if (currentHP <= 0.0f)
        {
            Death();
        }
        //if (currentHP < maxHP) { damageImage.color = flashCol; }
        //else
        //{
        //    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        //}
    }

    public void Damage(float damage)
    {
        if (damage > 0.0f)
            playerAudio.PlayOneShot(damageClip);

        if (currentHP < damage) {
            currentHP = 0;
        }
        else {
            currentHP = Mathf.Clamp(currentHP - damage, 0.0f, maxHP);
        }        
    }

    public void resetHP() {
        currentHP = startHP;
    }

    private void Death()
    {
        //currentLives--;
                
        //Particles
        if (deathParticle != null)
            deathParticle.Emit(1);

        this.gameObject.SetActive(false);
        NotifyGM();

        //if (currentLives <= 0) Destroy(gameObject);
    }

    private void NotifyGM()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.GetComponent<AudioSource>().PlayOneShot(deathClip);

        PlayerController pc = gameObject.GetComponent<PlayerController>();

        gm.PlayerDeath(pc.playerNum);
    }
}
