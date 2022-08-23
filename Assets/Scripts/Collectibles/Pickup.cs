using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       19-08-2022 19:30:37
================================================*/
    
public class Pickup : MonoBehaviour {
    public const int HEALTH_PICKUP_SFX = 7;
    public const int GEM_PICKUP_SFX = 6;

    public bool isGem, isHeal;

    private bool isCollected;

    public GameObject pickupEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isCollected) {
            if(isGem) {
                LevelManager.instance.gemCollected++;
                isCollected = true;
                DestroyPickup(GEM_PICKUP_SFX);
                UIController.instance.UpdateGemCollectedUI();
            }

            if(isHeal) {
                if (PlayerHealthController.instance.currentHealth >= PlayerHealthController.instance.maxHealth) {
                    return;
                }
                isCollected = true;
                DestroyPickup(HEALTH_PICKUP_SFX);
                PlayerHealthController.instance.HealPlayer();
            }
        }
    }

    private void DestroyPickup(int sfx) {
        Destroy(gameObject);
        Instantiate(pickupEffect, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(sfx);
    }
}