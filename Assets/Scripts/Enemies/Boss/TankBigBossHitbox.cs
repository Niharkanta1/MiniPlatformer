using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       14-09-2022 17:15:55
================================================*/
    
public class TankBigBossHitbox : MonoBehaviour {
    public BigTankController bossController;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && PlayerController.instance.transform.position.y > transform.position.y) {
            bossController.TakeHit();
            PlayerController.instance.Bounce();
            gameObject.SetActive(false);
        }
    }
}