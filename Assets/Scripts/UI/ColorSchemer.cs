using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ColorSchemer : MonoBehaviour {
    [SerializeField] private Shader colorSchemeShader;

    private Material colorSchemeMat;

    private List<Vector4[]> colorSchemes = null;
    private static int schemeIndex = -1;

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

        Vector4[] scheme14 = new Vector4[] {
            new Vector4(52, 56, 52, 255),
            new Vector4(255, 204, 167, 255)
        };

        Vector4[] scheme15 = new Vector4[] {
            new Vector4(10, 5, 50, 255),
            new Vector4(251, 182, 209, 255)
        };

        Vector4[] scheme16 = new Vector4[] {
            new Vector4(15, 87, 143, 255),
            new Vector4(251, 182, 209, 255)
        };

        Vector4[] scheme17 = new Vector4[] {
            new Vector4(36, 54, 104, 255),
            new Vector4(122, 127, 123, 255)
        };

        Vector4[] scheme18 = new Vector4[] {
            new Vector4(109, 61, 15, 255),
            new Vector4(152, 178, 18, 255)
        };

        Vector4[] scheme19 = new Vector4[] {
            new Vector4(79, 42, 70, 255),
            new Vector4(152, 178, 118, 255)
        };
        
        Vector4[] scheme20 = new Vector4[] {
            new Vector4(131, 45, 56, 255),
            new Vector4(229, 214, 209, 255)
        };

        Vector4[] scheme21 = new Vector4[] {
            new Vector4(90, 56, 51, 255),
            new Vector4(221, 141, 130, 255)
        };

        colorSchemes.Add(scheme1);
        colorSchemes.Add(scheme2);
        colorSchemes.Add(scheme3);
        colorSchemes.Add(scheme4);
        colorSchemes.Add(scheme5);
        colorSchemes.Add(scheme6);
        colorSchemes.Add(scheme7);
        colorSchemes.Add(scheme8);
        colorSchemes.Add(scheme9);
        colorSchemes.Add(scheme10);
        colorSchemes.Add(scheme11);
        colorSchemes.Add(scheme12);
        colorSchemes.Add(scheme13);
        colorSchemes.Add(scheme14);
        colorSchemes.Add(scheme15);
        colorSchemes.Add(scheme16);
        colorSchemes.Add(scheme17);
        colorSchemes.Add(scheme18);
        colorSchemes.Add(scheme19);
        colorSchemes.Add(scheme20);
        colorSchemes.Add(scheme21);

        if (schemeIndex == -1)
            schemeIndex = Random.Range(0, colorSchemes.Count);

        if (colorSchemeMat == null) {
            colorSchemeMat = new Material(colorSchemeShader);
            colorSchemeMat.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        colorSchemeMat.SetVector("col1", colorSchemes[schemeIndex][0]);
        colorSchemeMat.SetVector("col2", colorSchemes[schemeIndex][1]);
        Graphics.Blit(source, destination, colorSchemeMat);
    }

    public void Refresh() {
        schemeIndex = (schemeIndex + 1) % colorSchemes.Count;
    }
}
