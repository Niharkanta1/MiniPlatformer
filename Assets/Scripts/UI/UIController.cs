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
    public GameObject levelCompleteText;
    public RectTransform gemRectTransform;

    public Image fadeScreen;
    public float fadeSpeed;
    public float fadeTime;
    public bool shouldFadeToBlack, shouldFadeFromBlack;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        UpdateGemCollectedUI();
        FadeFromBlack();
    }

    private void Update() {
        if(shouldFadeToBlack) {
            fadeScreen.color = new Color(
                fadeScreen.color.r,
                fadeScreen.color.g,
                fadeScreen.color.b,
                Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            if(fadeScreen.color.a == 1) {
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

    public void UpdateHealthUI() {
        switch(PlayerHealthController.instance.currentHealth) {
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                AnimateHeart(heart3.rectTransform);
                break;
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartHalf;
                AnimateHeart(heart3.rectTransform);
                break;
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                AnimateHeart(heart2.rectTransform);
                break;
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartHalf;
                heart3.sprite = heartEmpty;
                AnimateHeart(heart2.rectTransform);
                break;
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                AnimateHeart(heart1.rectTransform);
                break;
            case 1:
                heart1.sprite = heartHalf;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                AnimateHeart(heart1.rectTransform);
                break;

            default:
                ClearHealthUI();
                break;
        }
    }

    public void UpdateGemCollectedUI() {
        gemText.text = LevelManager.instance.gemCollected.ToString();
        AnimateGems(gemRectTransform);
    }

    public void ClearHealthUI() {
        heart1.sprite = heartEmpty;
        heart2.sprite = heartEmpty;
        heart3.sprite = heartEmpty;
    }

    public void AnimateHeart(RectTransform rectTransform) {
        StopAllCoroutines();
        StartCoroutine(ScaleTransform(rectTransform, 2, 0.1f));
    }

    public void AnimateGems(RectTransform rectTransform) {
        StartCoroutine(ScaleTransform(rectTransform, 1, 0.15f));
    }

    private IEnumerator ScaleTransform(RectTransform rectTransform, int animateAmnt, float animateDuration) {
        for (int i = 0; i < animateAmnt; i++) {
            rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            yield return new WaitForSeconds(animateDuration);
            rectTransform.localScale = new Vector3(1f, 1f, 1f);
            yield return new WaitForSeconds(animateDuration);
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
}