using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       21-08-2022 16:42:58
================================================*/
    
public class StompBox : MonoBehaviour {
    private const int ENEMY_EXPLODE_SFX = 3;

    public GameObject deathEffect;
    public GameObject collectible;

    [Range(0, 100)]
    public float chanceToDrop;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Enemy") && PlayerController.instance.rigidBody.velocity.y < 0) {
            collision.transform.parent.gameObject.SetActive(false);
            Instantiate(deathEffect, collision.transform.position, collision.transform.rotation);
            AudioManager.instance.PlaySFX(ENEMY_EXPLODE_SFX);

            PlayerController.instance.Bounce();

            float dropSelect = Random.Range(0, 100f);
            if(dropSelect <= chanceToDrop) {
                Instantiate(collectible, collision.transform.position, collision.transform.rotation);
            }
        }
    }
}