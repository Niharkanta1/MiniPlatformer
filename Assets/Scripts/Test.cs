using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       04-09-2022 18:09:28
================================================*/

public class TestingTimers: MonoBehaviour {
	private void Start() {
		FunctionTimer.Create(()=> {
			Debug.Log("Do Something after 3 seconds");
		}, 3f);	
	}
}