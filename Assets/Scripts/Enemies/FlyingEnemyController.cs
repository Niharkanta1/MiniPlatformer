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

    public float attackRange;
    public float attackSpeed;
    public float nextAttackTimer;

    private Vector3 attackTarget;
    private float attackTimeCounter;
    private SpriteRenderer theSR;

    private void Start() {
        theSR = GetComponentInChildren<SpriteRenderer>();
        foreach(var point in points) {
            point.parent = null;
        }
    }

    private void Update() {

        if(attackTimeCounter > 0) {
            attackTimeCounter -= Time.deltaTime;

        } else {

            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > attackRange) {
                attackTarget = Vector3.zero;

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
            } else { // Attack Player
                if (attackTarget == Vector3.zero) {
                    attackTarget = PlayerController.instance.transform.position;
                }
                transform.position = Vector3.MoveTowards(transform.position,
                    attackTarget,
                    attackSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, attackTarget) <= 0.1f) {
                    attackTimeCounter = nextAttackTimer;
                    attackTarget = Vector3.zero;
                }
                if (transform.position.x < attackTarget.x) {
                    transform.localScale = new Vector3(-1, 1, 1);
                } else if (transform.position.x > attackTarget.x) {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }  

    }
}