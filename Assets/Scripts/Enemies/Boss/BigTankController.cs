using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       12-09-2022 19:25:46
================================================*/
    
public class BigTankController : MonoBehaviour {

    public enum BossState { shooting, hurt, moving };
    public BossState currentState;

    public Transform theBoss;
    public Animator anim;

    [Header("Movement")]
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    public bool moveRight;
    
    [Header("Shooting")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    public float shotCounter;

    [Header("Hurt")]
    public float hurtTime;
    public GameObject hitBox;
    private float hurtTimeCounter;

    [Header("Mines")]
    public GameObject mines;
    public Transform minePoint;
    public float timeBetweenMines;
    private float mineTimeCounter;

    private void Start() {
        currentState = BossState.shooting;
    }

    private void Update() {
        switch (currentState) {
            case BossState.shooting:
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0) {
                    shotCounter = timeBetweenShots;
                    var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
                    newBullet.transform.localScale = theBoss.localScale;
                }
                break;
            case BossState.hurt:
                if(hurtTimeCounter > 0) {
                    hurtTimeCounter -= Time.deltaTime;
                    if(hurtTimeCounter <= 0) {
                        currentState = BossState.moving;
                        mineTimeCounter = timeBetweenMines;
                    }
                }
                break;
            case BossState.moving:
                if(moveRight) {
                    theBoss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                    if(theBoss.position.x >= rightPoint.position.x) {
                        theBoss.localScale = new Vector3(1f, 1f, 1f);
                        moveRight = false;
                        EndMovement();
                    }
                } else {
                    theBoss.position += new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
                    if (theBoss.position.x <= leftPoint.position.x) {
                        theBoss.localScale = new Vector3(-1f, 1f, 1f);
                        moveRight = true;
                        EndMovement();
                    }
                }
                mineTimeCounter -= Time.deltaTime;
                if(mineTimeCounter <= 0) {
                    mineTimeCounter = timeBetweenMines;
                    Instantiate(mines, minePoint.position, minePoint.rotation);
                }
                break;
        }

#if UNITY_EDITOR
        if(Input.GetKeyDown(KeyCode.H)) {
            TakeHit();
        }

#endif
    }

    public void TakeHit() {
        currentState = BossState.hurt;
        hurtTimeCounter = hurtTime;
        anim.SetTrigger("Hit");
    }

    private void EndMovement() {
        currentState = BossState.shooting;
        shotCounter = 0f;
        anim.SetTrigger("Stop");
        hitBox.SetActive(true);
    }
}