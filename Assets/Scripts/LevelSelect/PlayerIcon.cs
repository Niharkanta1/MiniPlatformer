using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       05-09-2022 22:55:06
================================================*/
    
public class PlayerIcon : MonoBehaviour {
    public MapPoint startPoint;
    public MapPoint currentPoint;
    public float moveSpeed = 10f;

    private bool levelLoading;

    private void Start() {
        currentPoint = startPoint;
        transform.position = currentPoint.transform.position;
    }

    private void Update() {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) > 0.1f || levelLoading)
            return;

        if(Input.GetAxisRaw("Horizontal") > 0.5f) {
            if(currentPoint.right != null) {
                SetNextPoint(currentPoint.right);
            }
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5f) {
            if (currentPoint.left != null) {
                SetNextPoint(currentPoint.left);
            }
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f) {
            if (currentPoint.up != null) {
                SetNextPoint(currentPoint.up);
            }
        }
        if (Input.GetAxisRaw("Vertical") < -0.5f) {
            if (currentPoint.down != null) {
                SetNextPoint(currentPoint.down);
            }
        }
        if(currentPoint.isLevel) {
            if(Input.GetButtonDown("Jump")) {
                levelLoading = true;
                LSManager.instance.LoadLevel();
            }
        }
    }

    public void SetNextPoint(MapPoint next) {
        currentPoint = next;
    } 
}