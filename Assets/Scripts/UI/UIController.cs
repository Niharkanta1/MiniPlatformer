using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       15-08-2022 22:11:15
================================================*/
    
public class UIController : MonoBehaviour {
    public static UIController instance;
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartEmpty, heartHalf;

    public Text gemText;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateGemCollectedUI();
    }

    public void UpdateHealthUI() {
        switch(PlayerHealthController.instance.currentHealth) {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                break;

            default:
                ClearHealthUI();
                break;
        }
    }

    public void UpdateGemCollectedUI() {
        gemText.text = LevelManager.instance.gemCollected.ToString();
    }

    public void ClearHealthUI() {
        heart1.sprite = heartEmpty;
        heart2.sprite = heartEmpty;
        heart3.sprite = heartEmpty;
    }
}