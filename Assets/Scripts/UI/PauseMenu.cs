using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       24-08-2022 11:22:23
================================================*/

public class PauseMenu : MonoBehaviour {
    public static PauseMenu instance;

    public string levelSelect, mainMenu;
    public GameObject pauseScreen;
    public bool isPaused;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        pauseScreen.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            PauseToggle();
        }
    }

    public void PauseToggle() {
        isPaused = isPaused ? false : true;
        pauseScreen.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void LevelSelect() {
        PlayerPrefs.SetString("CurrentLevel", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }

    public void MainMenu() {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}