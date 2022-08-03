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
    public int currentHealth, maxHealth = 3;

    private void Start() {
        currentHealth = maxHealth;
    }

    private void Update() {
        
    }

    public void DealDamage() {
        currentHealth--;
        if(currentHealth <= 0) {
            gameObject.SetActive(false);
        }
    }
}