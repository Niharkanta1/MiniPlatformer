using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  Nihar
Company:    DWG
Date:       04-09-2022 18:09:28
================================================*/
    
public class FunctionTimer : MonoBehaviour {

    private static List<FunctionTimer> activeTimersList;
    private static GameObject initGameObject;

    private Action action;
    private float timer;
    private string timerName;
    private GameObject timerGameObject;
    private bool isDestroyed;

    private static void InitIfNeeded() {
        if (initGameObject == null) {
            initGameObject = new GameObject("FunctionTimer_InitGameObject");
            activeTimersList = new List<FunctionTimer>();
        }
    }

    private class MonobehaviourHook : MonoBehaviour {
        public Action onUpdate;
        private void Update() {
            onUpdate?.Invoke();
        }
    }

    public static FunctionTimer Create(Action action, float timer, string timerName = null) {
        InitIfNeeded();

        GameObject gameObject = new GameObject("FunctionTimer", typeof(MonobehaviourHook));
        FunctionTimer functionTimer = new FunctionTimer(action, timer, timerName, gameObject);
        activeTimersList.Add(functionTimer);

        gameObject.GetComponent<MonobehaviourHook>().onUpdate = functionTimer.Update;
        return functionTimer;
    }

    public static void StopTimer(string timerName) {
        for(int i=0; i < activeTimersList.Count; i++) {
            if (activeTimersList[i].timerName == timerName) {
                activeTimersList[i].DestroySelf();
                i--;
            }
        }
    }

    private static void RemoveTimer(FunctionTimer functionTimer) {
        InitIfNeeded();
        activeTimersList.Remove(functionTimer);
    }

    private FunctionTimer(Action action, float timer, string timerName, GameObject gameObject) {
        this.action = action;
        this.timer = timer;
        this.timerGameObject = gameObject;
        this.timerName = timerName;
        isDestroyed = false;
    }

    private void Update() {
        if (isDestroyed)
            return;

        timer -= Time.deltaTime;
        if (timer < 0) {
            action();
            DestroySelf();
        }
    }

    private void DestroySelf() {
        isDestroyed = true;
        UnityEngine.Object.Destroy(timerGameObject);
        RemoveTimer(this);
    }
}