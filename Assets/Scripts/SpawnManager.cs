using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       17-08-2022 23:13:16
================================================*/
    
public class SpawnManager : MonoBehaviour {
    public static SpawnManager instance;

    public Checkpoint[] checkPoints;
    public Vector3 spawnPoint;
    public float waitToRespawn;

    private void Awake() {
        instance = this;
    }

    private void Start() {
       checkPoints = FindObjectsOfType<Checkpoint>();
       spawnPoint = PlayerController.instance.transform.position;
    }

    private void Update() {
        
    }

    public void ResetAllCheckpoints() {
        for (int i = 0; i < checkPoints.Length; i++) {
            checkPoints[i].ResetCheckpoint();
        }
    }
    
    public void SetSpawnPoint(Vector3 newSpawnPoint) {
        spawnPoint = newSpawnPoint;
    }

    public void RespawnPlayer() {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine() {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn - (1/ UIController.instance.fadeSpeed));
        UIController.instance.FadeToBlack();
        yield return new WaitForSeconds((1f / UIController.instance.fadeSpeed) + UIController.instance.fadeTime);
        UIController.instance.FadeFromBlack();
        PlayerController.instance.transform.position = spawnPoint;
        PlayerController.instance.gameObject.SetActive(true);
        PlayerHealthController.instance.ResetPlayerHealth();
    }
}