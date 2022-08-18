using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       17-08-2022 22:56:22
================================================*/
    
public class Checkpoint : MonoBehaviour {

    public SpriteRenderer theSR;
    public Sprite checkPointOn, checkPointOff;

    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.CompareTag("Player")) {
            SpawnManager.instance.ResetAllCheckpoints();
            theSR.sprite = checkPointOn;
            SpawnManager.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint() {
        theSR.sprite = checkPointOff;
    }
}