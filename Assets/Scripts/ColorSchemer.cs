using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColorSchemer : MonoBehaviour {
    public Shader colorSchemeShader;

    private Material colorSchemeMat;

    private List<Vector4[]> colorSchemes = null;
    private Vector4[] scheme = null;

    void Start() {
        colorSchemes = new List<Vector4[]>();

        Vector4[] scheme1 = new Vector4[] {
            new Vector4(18, 18, 22, 255),
            new Vector4(232, 230, 225, 255)
        };

        scheme = scheme1;

        if (colorSchemeMat == null) {
            colorSchemeMat = new Material(colorSchemeShader);
            colorSchemeMat.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        colorSchemeMat.SetVector("col1", scheme[0]);
        colorSchemeMat.SetVector("col2", scheme[1]);
        Graphics.Blit(source, destination, colorSchemeMat);
    }
}
