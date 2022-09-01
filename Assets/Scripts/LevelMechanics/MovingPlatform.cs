using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       25-08-2022 23:12:27
================================================*/
    
public class MovingPlatform : MonoBehaviour {
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;

    public Transform platform;

    private void Update() {
        platform.position = Vector3.MoveTowards(platform.position, 
            points[currentPoint].position, 
            moveSpeed * Time.deltaTime);

        if(Vector3.Distance(platform.position, points[currentPoint].position) < 0.05f) {
            currentPoint++;
            if(currentPoint >= points.Length) {
                currentPoint = 0;
            }
        }

    }
}