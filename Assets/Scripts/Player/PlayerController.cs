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
    public const float GROUND_CHECK_RADIUS = 0.2f;

    public float moveSpeed = 8f;
    public Rigidbody2D rigidBody;
    public Animator animator;

    public float jumpForce = 12f;

    public Transform groundCheckPoint;
    public LayerMask groundLayerMask;

    public bool isGrounded;
    public bool canDoubleJump;

    private void Start() {
        animator = GetComponent<Animator>();

    }

    private void Update() {
        rigidBody.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rigidBody.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, GROUND_CHECK_RADIUS, groundLayerMask);
        if(isGrounded) {
            canDoubleJump = true;
        }
        
        if(Input.GetButtonDown("Jump")) {
            if(isGrounded) {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);

            } else {

                if (canDoubleJump) {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
        }
        if(rigidBody.velocity.x < 0) {
            transform.localScale = (new Vector3(-1, 1, 1));
        } else if (rigidBody.velocity.x > 0) {
            transform.localScale = (new Vector3(1, 1, 1));
        } 
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("moveSpeedX", Mathf.Abs(rigidBody.velocity.x));
        animator.SetFloat("moveSpeedY", rigidBody.velocity.y);
    }

}