using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       19-08-2022 19:42:33
================================================*/
    
public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public int gemCollected;
    public string levelToLoad;

    public float timeInLevel;

    private void Awake() {
        instance = this;
    }
    private void Start() {
        timeInLevel = 0f;
    }

    private void Update() {
        timeInLevel += Time.deltaTime;
    }

    public void EndLevel() {
        StartCoroutine(EndLevelCoroutine());
    }

    private IEnumerator EndLevelCoroutine() {
        PlayerController.instance.StopInput();

        /* Alternate Style
         * Mario Style Ending.
         * Keep the player to move towards right, 
         * Extend the ground and stop the camera to follow. 
         */

        UIController.instance.levelCompleteText.SetActive(true);
        yield return new WaitForSeconds(2f);
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + 0.25f);

        SaveLevelData();
        SceneManager.LoadScene(levelToLoad);
    }

    private void SaveLevelData() {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems")) {
            if(PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < gemCollected) {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
            }
        } else {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemCollected);
        }

        if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time")) {
            if (PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name) > timeInLevel) {
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
            }
        } else {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }
    }
}