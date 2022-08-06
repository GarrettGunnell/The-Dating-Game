using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Camera))]
public class ColorSchemer : MonoBehaviour {

    [SerializeField] private Shader colorSchemeShader;
    [SerializeField] private ColorSchemeData colorSchemes;

    private Material colorSchemeMat;

    private static int schemeIndex = -1;

    void Start() {

        if (schemeIndex == -1)
            schemeIndex = Random.Range(0, colorSchemes.Count);

        if (colorSchemeMat == null) {
            colorSchemeMat = new Material(colorSchemeShader);
            colorSchemeMat.hideFlags = HideFlags.HideAndDontSave;
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination) {
        var colors = colorSchemes[schemeIndex];
        colorSchemeMat.SetVector("col1", colors.Darker);
        colorSchemeMat.SetVector("col2", colors.Brighter);
        Graphics.Blit(source, destination, colorSchemeMat);
    }

    public void Refresh() {
        schemeIndex = (schemeIndex + 1) % colorSchemes.Count;
    }
}