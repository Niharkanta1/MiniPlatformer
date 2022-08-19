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
    public bool isGem;

    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && !isCollected) {
            if(isGem) {
                LevelManager.instance.gemCollected++;
                isCollected = true;
                Destroy(gameObject);
            }
        }
    }
}