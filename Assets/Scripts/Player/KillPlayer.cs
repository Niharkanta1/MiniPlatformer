using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       17-08-2022 23:06:55
================================================*/
    
public class KillPlayer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            PlayerHealthController.instance.PlayerDied();
        }
    }

}