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
    public int currentHealth, maxHealth = 6;
    public float iFrameTime;

    private float iFrameCounter;
    private SpriteRenderer theSR;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthUI();

        theSR = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(iFrameCounter >= 0) {
            iFrameCounter -= Time.deltaTime;
            if(iFrameCounter <= 0) {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void DealDamage() {
        if (iFrameCounter > 0)
            return;
        
        currentHealth--;
        if(currentHealth <= 0) {
            currentHealth = 0;
            gameObject.SetActive(false);
        }  else {
            iFrameCounter = iFrameTime;
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0.5f);
        }

        UIController.instance.UpdateHealthUI();
    }
}