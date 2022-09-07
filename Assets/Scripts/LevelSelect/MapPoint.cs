using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       05-09-2022 22:38:50
================================================*/
    
public class MapPoint : MonoBehaviour {
    public MapPoint up, right, down, left;
    public bool isLevel;
    public string levelToLoad, levelToCheck;
    public string levelName;
    public bool isLocked;

    private void Start() {
        levelName = GetReadableLevelName(levelToLoad);
        if(isLevel && levelToLoad != null) {
            isLocked = true; 
            if (levelToCheck != null) {
                if(PlayerPrefs.HasKey(levelToCheck+"_unlocked") && PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1) {
                    isLocked = false;
                } else {
                    isLocked = true;
                }
            }
            if(levelToCheck == levelToLoad) {
                isLocked = false;
            }
        }
    }

    private string GetReadableLevelName(string levelToLoad) {
        if (levelToLoad == null || levelToLoad == "")
            return "LEVEL INFORMATION NOT AVAILABLE";

        return Regex.Replace(levelToLoad, "(\\B[A-Z])", " $1");
    }
}