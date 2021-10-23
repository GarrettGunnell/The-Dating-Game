using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leave : MonoBehaviour {
    public Texture2D defaultTex, hoverTex, disabledTex;

    private bool isEnabled;
    private Material material;

    void Start() {
        material = GetComponent<Renderer>().material;
    }

    void Update() {

    }

    void OnMouseOver() {
        if (isEnabled) {
            material.SetTexture("_MainTex", hoverTex);
            UI.changeCursor(true);
        }
    }

    void OnMouseExit() {
        if (isEnabled) {
            material.SetTexture("_MainTex", defaultTex);
            UI.changeCursor(false);
        }
    }

    public void SetDisabled() {
        isEnabled = false;
        material.SetTexture("_MainTex", disabledTex);
    }

    public void SetEnabled() {
        isEnabled = true;
        material.SetTexture("_MainTex", defaultTex);
    }
}
