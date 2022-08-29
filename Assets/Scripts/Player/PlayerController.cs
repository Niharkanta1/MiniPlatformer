using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       24-07-2022 17:00:15
================================================*/

public class PlayerController : MonoBehaviour {
    public static PlayerController instance;

    public const float GROUND_CHECK_RADIUS = 0.3f;
    
    public const int PLAYER_JUMP_SFX = 10;
    public const int PLAYER_HURT_SFX = 9;

    public float moveSpeed = 8f;
    public Rigidbody2D rigidBody;
    public Animator animator;

    public float jumpForce = 12f;
    public float bounceForce = 10f;

    public Transform groundCheckPoint;
    public LayerMask groundLayerMask;

    public bool isGrounded;
    public bool canDoubleJump;
    public bool facingRight;
    public float knockbackTime, knockbackForce;

    private float knockbackCounter;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        animator = GetComponent<Animator>();

    }

    private void Update() {
        if (PauseMenu.instance.isPaused)
            return;

        if(knockbackCounter <= 0) {
            rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rigidBody.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, GROUND_CHECK_RADIUS, groundLayerMask);
            if (isGrounded) {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump")) {
                if (isGrounded) {
                    PerformJump();
                } else {

                    if (canDoubleJump) {
                        PerformJump();
                        canDoubleJump = false;
                    }
                }
            }
            if (rigidBody.velocity.x < 0) {
                transform.localScale = (new Vector3(-1, 1, 1));
                facingRight = false;
            } else if (rigidBody.velocity.x > 0) {
                transform.localScale = (new Vector3(1, 1, 1));
                facingRight = true;
            }
        } else {
            knockbackCounter -= Time.deltaTime;
            if (facingRight) {
                rigidBody.velocity = new Vector2(-knockbackForce, rigidBody.velocity.y);
            } else {
                rigidBody.velocity = new Vector2(knockbackForce, rigidBody.velocity.y);
            }
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("moveSpeedX", Mathf.Abs(rigidBody.velocity.x));
        animator.SetFloat("moveSpeedY", rigidBody.velocity.y);
    }

    private void PerformJump() {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        AudioManager.instance.PlaySFX(PLAYER_JUMP_SFX);
    }

    public void Knockback() {
        animator.SetTrigger("isHurt");
        knockbackCounter = knockbackTime;
        rigidBody.velocity = new Vector2(0f, knockbackForce);
        AudioManager.instance.PlaySFX(PLAYER_HURT_SFX);
    }

    public void Bounce() {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, bounceForce);
        AudioManager.instance.PlaySFX(PLAYER_JUMP_SFX);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Platform")) {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Platform")) {
            transform.parent = null;
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected() {
        // Draw a yellow sphere for the ground check
        Gizmos.color = new Color(0, 0, 1, 0.5f);
        Gizmos.DrawSphere(groundCheckPoint.position, GROUND_CHECK_RADIUS);
    }

#endif
}