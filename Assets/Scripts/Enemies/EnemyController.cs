using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       21-08-2022 15:34:01
================================================*/

public class EnemyController : MonoBehaviour {
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    public bool facingRight;
    public float moveTimer, waitTimer;

    private Rigidbody2D theRB;
    private Animator anim;
    private float moveCounter, waitCounter;

    private void Start() {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        moveCounter = moveTimer;
        waitCounter = waitTimer;
    }

    private void Update() {
        if(moveCounter > 0) {
            moveCounter -= Time.deltaTime;

            MoveEnemy();
            anim.SetBool("isMoving", true);

            if (moveCounter <= 0) {
                waitCounter = Random.Range(waitTimer * 0.75f, waitTimer * 1.25f);
            }
        } else if(waitCounter > 0){
            waitCounter -= Time.deltaTime;

            theRB.velocity = new Vector2(0f, theRB.velocity.y);
            anim.SetBool("isMoving", false);

            if (waitCounter <= 0) {
                moveCounter = Random.Range(waitTimer * 0.75f, waitTimer * 1.25f);
            }
        }
    }

    private void MoveEnemy() {
        if (facingRight) {
            transform.localScale = new Vector3(-1, 1, 1);
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
            if (transform.position.x > rightPoint.position.x) {
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                facingRight = false;
            }
        } else {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            if (transform.position.x < leftPoint.position.x) {
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                facingRight = true;
            }
        }
    }
}