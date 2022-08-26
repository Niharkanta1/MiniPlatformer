using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       26-08-2022 21:17:19
================================================*/
    
public class FlyingEnemyController : MonoBehaviour {
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;

    public SpriteRenderer theSR;
    public float attackRange;
    public float attackSpeed;

    private void Start() {
        theSR = GetComponentInChildren<SpriteRenderer>();
        foreach(var point in points) {
            point.parent = null;
        }
    }

    private void Update() {

        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > attackRange) {

            transform.position = Vector3.MoveTowards(transform.position,
            points[currentPoint].position,
            moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, points[currentPoint].position) < 0.05f) {
                currentPoint++;
                if (currentPoint >= points.Length) {
                    currentPoint = 0;
                }
            }
            if (transform.position.x < points[currentPoint].position.x) {
                transform.localScale = new Vector3(-1, 1, 1);
            } else if (transform.position.x > points[currentPoint].position.x) {
                transform.localScale = new Vector3(1, 1, 1);
            }
        } else {

            transform.position = Vector3.MoveTowards(transform.position,
                PlayerController.instance.transform.position,
                attackSpeed * Time.deltaTime);
        }

        

    }
}