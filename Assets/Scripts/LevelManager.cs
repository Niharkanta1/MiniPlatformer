using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       19-08-2022 19:42:33
================================================*/
    
public class LevelManager : MonoBehaviour {
    public static LevelManager instance;
    public int gemCollected;

    private void Awake() {
        instance = this;
    }
}