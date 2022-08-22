using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       04-08-2022 00:54:49
================================================*/
    
public class PlayerHealthController : MonoBehaviour {

    public static PlayerHealthController instance;

    public const int PLAYER_DEATH_SFX = 8;

    public int currentHealth, maxHealth = 6;
    public bool godMode;
    public float iFrameTime;
    public GameObject deathEffect;

    private float iFrameCounter;
    private SpriteRenderer theSR;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        ResetPlayerHealth();

        theSR = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(iFrameCounter > 0) {
            iFrameCounter -= Time.deltaTime;
            if(iFrameCounter <= 0) {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage() {
        if (iFrameCounter > 0)
            return;
        
        if(!godMode) 
            currentHealth--;

        if(currentHealth <= 0) {
            PlayerDied();
        }  else {
            iFrameCounter = iFrameTime;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
            PlayerController.instance.Knockback();
        }

        UIController.instance.UpdateHealthUI();
    }

    public void PlayerDied() {
        currentHealth = 0;
        Instantiate(deathEffect, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(PLAYER_DEATH_SFX);
        SpawnManager.instance.RespawnPlayer();
    }

    public void ResetPlayerHealth() {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthUI();
    }

    public void HealPlayer() {
        currentHealth++;
        if(currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthUI();
    }
}