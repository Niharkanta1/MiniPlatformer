using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       22-08-2022 22:44:58
================================================*/
    
public class MainMenu : MonoBehaviour {

    public string startScene;

    public void StartGame() {
        SceneManager.LoadScene(startScene);
    }

    public void QuitGame() {
        Application.Quit();
    }
}