using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Credits : MonoBehaviour {

    public VideoPlayer vidPlayer;
    public ColorSchemer colorSchemer;

    void Start() {
    }

    void Update() {
        if (vidPlayer.frame > 0 && vidPlayer.isPlaying == false) {
            colorSchemer.enabled = true;
            gameObject.SetActive(false);
        }
    }
}
