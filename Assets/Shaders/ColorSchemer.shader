Shader "Hidden/ColorSchemer" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
    }

    CGINCLUDE
        #include "UnityCG.cginc"

        sampler2D _MainTex;

        struct VertexData {
            float4 vertex : POSITION;
            float2 uv : TEXCOORD0;
        };

        struct v2f {
            float2 uv : TEXCOORD0;
            float4 vertex : SV_POSITION;
        };

        v2f vp(VertexData v) {
            v2f f;
            f.vertex = UnityObjectToClipPos(v.vertex);
            f.uv = v.uv;
            
            return f;
        }
    ENDCG

    SubShader {
        Cull Off ZWrite Off ZTest Always

        Pass {
            CGPROGRAM
            #pragma vertex vp
            #pragma fragment fp

            #include "UnityCG.cginc"

            fixed4 fp(v2f i) : SV_Target {
                fixed4 col = tex2D(_MainTex, i.uv);

                fixed4 col1 = fixed4(18.0f / 255.0f, 18.0f / 255.0f, 22.0f / 255.0f, 1.0f);
                fixed4 col2 = fixed4(232.0f / 255.0f, 230.0f / 255.0f, 225.0f / 255.0f, 1.0f);

                col = lerp(col1, col2, col.r);

                return col;
            }
            ENDCG
        }
    }
}
