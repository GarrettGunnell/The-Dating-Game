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
            new Vector4(21, 22, 18, 255),
            new Vector4(232, 225, 225, 255)
        };
        
        Vector4[] scheme2 = new Vector4[] {
            new Vector4(62, 35, 44, 255),
            new Vector4(237, 246, 214, 255)
        };

        Vector4[] scheme3 = new Vector4[] {
            new Vector4(18, 18, 23, 255),
            new Vector4(232, 246, 214, 255)
        };

        Vector4[] scheme4 = new Vector4[] {
            new Vector4(15, 10, 14, 255),
            new Vector4(240, 246, 240, 255)
        };

        Vector4[] scheme5 = new Vector4[] {
            new Vector4(38, 31, 96, 255),
            new Vector4(189, 231, 193, 255)
        };
        

        scheme = scheme5;

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
