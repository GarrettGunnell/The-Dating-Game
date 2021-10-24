using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Date : MonoBehaviour {
    public Texture2D defaultTex, hoverTex;

    private Material material;

    void Start() {
        material = GetComponent<Renderer>().material;
    }

    void OnMouseOver() {
        material.SetTexture("_MainTex", hoverTex);
        MainMenu.changeCursor(true);
    }

    void OnMouseExit() {
        material.SetTexture("_MainTex", defaultTex);
        MainMenu.changeCursor(false);
    }
}
