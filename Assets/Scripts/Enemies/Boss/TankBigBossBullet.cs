using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       13-09-2022 22:45:12
================================================*/
    
public class TankBigBossBullet : MonoBehaviour {
    public const int BULLET_SHOT_SFX = 2;
    public const int BULLET_IMPACT = 1;
    public float bulletSpeed;
    private void Start() {
        AudioManager.instance.PlaySFX(BULLET_SHOT_SFX);
    }
    private void Update() {
        transform.position += new Vector3(-bulletSpeed * transform.localScale.x * Time.deltaTime, 0f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Player")) {
            PlayerHealthController.instance.DealDamage();
        }
        AudioManager.instance.PlaySFX(BULLET_IMPACT);
        Destroy(gameObject);
    }
}