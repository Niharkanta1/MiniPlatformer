using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       29-08-2022 22:10:45
================================================*/
    
public class Switch : MonoBehaviour {
    public GameObject objectToSwitch;
    public Sprite downSprite;
    public bool deactivateOnSwitch;

    private bool hasSwitched;
    private SpriteRenderer theSR;

    private void Start() {
        theSR = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player") && !hasSwitched) {

            if(deactivateOnSwitch) {
                objectToSwitch.SetActive(false);
            } else {
                objectToSwitch.SetActive(true);
            }

            theSR.sprite = downSprite;
            hasSwitched = true;
        }

    }
}