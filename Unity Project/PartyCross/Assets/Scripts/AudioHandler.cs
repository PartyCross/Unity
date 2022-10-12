using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [SerializeField] GameObject music;
    [SerializeField] GameObject deathSound;


    public void KillPlayer() {
        this.music.GetComponent<AudioSource>().Pause();
        this.deathSound.GetComponent<AudioSource>().Play();
    }

    public void RespawnPlayer() {
        this.deathSound.GetComponent<AudioSource>().Pause();
        this.music.GetComponent<AudioSource>().UnPause();
    }
}
