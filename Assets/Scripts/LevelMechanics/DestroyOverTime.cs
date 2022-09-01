using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       20-08-2022 12:16:05
================================================*/
    
public class DestroyOverTime : MonoBehaviour {
    public float lifespan;

    private void Update() {
        Destroy(gameObject, lifespan);
    }
}