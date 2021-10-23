using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : MonoBehaviour {
    public Texture2D defaultTex, hoverTex, disabledTex;

    private bool isEnabled;
    private Material material;

    void Start() {
        material = GetComponent<Renderer>().material;
    }

    void Update() {

    }

    void OnMouseOver() {
        material.SetTexture("_MainTex", hoverTex);
    }

    void OnMouseExit() {
        material.SetTexture("_MainTex", defaultTex);
    }
}
