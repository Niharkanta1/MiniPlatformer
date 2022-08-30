using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       30-08-2022 22:54:04
================================================*/
    
public class LevelExit : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            LevelManager.instance.EndLevel();
        }
    }
}