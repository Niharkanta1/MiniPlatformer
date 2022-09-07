using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       06-09-2022 23:10:57
================================================*/
    
public class LSManager : MonoBehaviour {
    public static LSManager instance;
    public PlayerIcon player;

    private void Awake() {
        instance = this;
    }

    public void LoadLevel() {
        StartCoroutine(LoadLevelCoroutine());
    }

    private IEnumerator LoadLevelCoroutine() {
        LSUIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / LSUIController.instance.fadeSpeed) + 0.25f);
        SceneManager.LoadScene(player.currentPoint.levelToLoad);
    }
}