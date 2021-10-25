using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refresh : MonoBehaviour {

    public AudioSource audioSource;
    public ColorSchemer colorSchemer;

    private Material material;

    void Start() {
        audioSource.Stop();
    }

    void OnMouseOver() {
        UI.changeCursor(true);
    }

    void OnMouseExit() {
        UI.changeCursor(false);
    }

    void OnMouseDown() {
        audioSource.Play();
        colorSchemer.Refresh();
    }
}
