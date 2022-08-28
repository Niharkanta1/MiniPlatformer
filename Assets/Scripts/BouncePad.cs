using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       28-08-2022 09:47:31
================================================*/
    
public class BouncePad : MonoBehaviour {

    public const int BOUNCE_SFX = 5;
    [Range(0,1)]
    public float sfxPitch = 0.2f;
    public float bounceForce;
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Player")) {
            PlayerController.instance.rigidBody.velocity = new Vector2(
                PlayerController.instance.rigidBody.velocity.x,
                bounceForce);

            anim.SetTrigger("Bounce");
            AudioManager.instance.PlaySFX(BOUNCE_SFX, sfxPitch);
        }
    }
}