using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       07-09-2022 18:28:27
================================================*/
    
public class LSUIController : MonoBehaviour {
    public static LSUIController instance;
    public Image fadeScreen;
    public float fadeSpeed;
    public float fadeTime;
    public bool shouldFadeToBlack, shouldFadeFromBlack;

    public GameObject levelInfoPanel;
    public Text levelName;
    
    private void Awake() {
        instance = this;    
    }

    private void Start() {
        FadeFromBlack(); 
    }

    private void Update() {
        if (shouldFadeToBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 1) {
                shouldFadeToBlack = false;
            }
        }
        if (shouldFadeFromBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            if (fadeScreen.color.a == 0) {
                shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack() {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack() {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }

    public void ShowInfo(MapPoint mapPoint) {
        levelName.text = mapPoint.levelName;
        levelInfoPanel.SetActive(true);
    }

    public void HideInfo() {
        levelInfoPanel.SetActive(false);
    }
}