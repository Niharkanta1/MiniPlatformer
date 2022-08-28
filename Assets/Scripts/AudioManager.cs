using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*=============================================
Product:    2DPlatformerMini v1.0
Developer:  nihar
Company:    DWG
Date:       22-08-2022 15:44:34
================================================*/
    
public class AudioManager : MonoBehaviour {
    public static AudioManager instance;

    public AudioSource[] soundEffects;
    public AudioSource bgm, levelEndMusic;

    private void Awake() {
        instance = this;
    }

    public void PlaySFX(int soundToPlay) {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f, 1.1f);
        soundEffects[soundToPlay].Play();
    }

    public void PlaySFX(int soundToPlay, float pitch) {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(.9f * pitch, 1.1f * pitch);
        soundEffects[soundToPlay].Play();
    }
}