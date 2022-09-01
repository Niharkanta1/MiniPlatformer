using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       04-08-2022 01:00:47
================================================*/
    
public class DamagePlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            collision.GetComponent<PlayerHealthController>().DealDamage();
        }
    }
    
}