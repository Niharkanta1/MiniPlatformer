using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       15-09-2022 11:36:56
================================================*/
    
public class TankBigBossMine : MonoBehaviour {
    public const int MINE_EXPLODE_SFX = 3;
    public GameObject explosion;
    public float autoExplosionTime;

    private void Update() {
        autoExplosionTime -= Time.deltaTime;
        if(autoExplosionTime <= 0) {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            Explode();
            PlayerHealthController.instance.DealDamage();
        }
    }

    public void Explode() {
        AudioManager.instance.PlaySFX(MINE_EXPLODE_SFX);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
}