using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       30-07-2022 16:05:52
================================================*/
    
public class CameraController : MonoBehaviour {
    public Transform farBackGround, midBackGround;
    public Transform playerTarget;

    private Vector2 lastPos;

    private void Start() {
        lastPos = transform.position;
    }

    private void Update() {
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);
        farBackGround.position += new Vector3(amountToMove.x, amountToMove.y, 0);
        midBackGround.position += new Vector3(amountToMove.x, amountToMove.y, 0) * 0.5f;
        lastPos = transform.position;
    }
}