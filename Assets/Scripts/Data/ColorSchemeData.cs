using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSchemeData", menuName = "ScriptableObjects/ColorSchemeData")]
public class ColorSchemeData : ScriptableObject
{
    [Serializable]
    public class Data
    {
        [SerializeField] private Color brighter = Color.white;
        [SerializeField] private Color darker = Color.black;

        private Vector4 ToVec4(Color color)
        {
            Func<float, float> f = (a) => Mathf.Floor(a * 256);
            return new Vector4(f(color.r), f(color.g), f(color.b), f(color.a));
        }

        public Data(Vector4 d, Vector4 b)
        {
            b /= 255;
            d /= 255;
            brighter = new Color(b.x, b.y, b.z, b.w);
            darker = new Color(d.x, d.y, d.z, d.w);
        }

        public Vector4 Brighter => ToVec4(brighter);
        public Vector4 Darker => ToVec4(darker);
    }
    [SerializeField] private Data[] colorSchemes;

    public int Count => colorSchemes.Length;
    public Data this[int i] => colorSchemes[i];
}