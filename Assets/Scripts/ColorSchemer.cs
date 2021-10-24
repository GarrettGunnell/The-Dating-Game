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

        Vector4[] scheme6 = new Vector4[] {
            new Vector4(26, 24, 11, 255),
            new Vector4(246, 217, 81, 255)
        };
        
        Vector4[] scheme7 = new Vector4[] {
            new Vector4(14, 16, 14, 255),
            new Vector4(200, 40, 45, 255)
        };

        Vector4[] scheme8 = new Vector4[] {
            new Vector4(9, 8, 11, 255),
            new Vector4(170, 20, 45, 255)
        };

        Vector4[] scheme9 = new Vector4[] {
            new Vector4(35, 11, 12, 255),
            new Vector4(255, 249, 225, 255)
        };
        
        Vector4[] scheme10 = new Vector4[] {
            new Vector4(27, 27, 30, 255),
            new Vector4(232, 184, 122, 255)
        };

        Vector4[] scheme11 = new Vector4[] {
            new Vector4(24, 25, 22, 255),
            new Vector4(213, 117, 206, 255)
        };

        Vector4[] scheme12 = new Vector4[] {
            new Vector4(116, 11, 16, 255),
            new Vector4(135, 255, 198, 255)
        };
        
        Vector4[] scheme13 = new Vector4[] {
            new Vector4(18, 72, 56, 255),
            new Vector4(255, 174, 52, 255)
        };

        scheme = scheme13;

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
