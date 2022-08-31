using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       29-08-2022 22:34:15
================================================*/
    
public class Slammer : MonoBehaviour {
    public Transform theSlammer, slammerTarget;
    public float slamSpeed, resetSpeed;
    public float waitAfterSlam, cooldownTime;
    public float slammerTriggerRange = 2f;

    private Vector3 startPoint;
    private float waitCounter, cooldownCounter;
    private bool slamming, resetting;

    private void Start() {
        startPoint = theSlammer.position;
    }

    private void Update() {
        if(cooldownCounter >= 0f) {
            cooldownCounter -= Time.deltaTime;
            return;
        }

        if(!slamming && !resetting) {
            if (Vector3.Distance(slammerTarget.position, PlayerController.instance.transform.position) < slammerTriggerRange) {
                slamming = true;
                waitCounter = waitAfterSlam;
            }
        }
        if(slamming) {
            theSlammer.position = Vector3.MoveTowards(theSlammer.position, slammerTarget.position, slamSpeed * Time.deltaTime);

            if(Vector3.Distance(theSlammer.position, slammerTarget.position) < 0.05f) {
                waitCounter -= Time.deltaTime;
                if(waitCounter <= 0) {
                    slamming = false;
                    resetting = true;
                }
            }
        }

        if (resetting) {
            theSlammer.position = Vector3.MoveTowards(theSlammer.position, startPoint, resetSpeed * Time.deltaTime);

            if (Vector3.Distance(theSlammer.position, startPoint) < 0.05f) {
                resetting = false;
                cooldownCounter = cooldownTime;
            }
        }
    }


#if UNITY_EDITOR

    private void OnDrawGizmosSelected() {
        // Draw a red cube for the area
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(slammerTarget.position, new Vector3(2 * slammerTriggerRange, 1f, 0f));
    }

#endif
}