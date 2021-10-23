using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColorSchemer : MonoBehaviour {
    public Shader colorSchemeShader;

    private Material colorSchemeMat;

    void Start() {
        if (colorSchemeMat == null) {
            colorSchemeMat = new Material(colorSchemeShader);
            colorSchemeMat.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, colorSchemeMat);
    }
}
