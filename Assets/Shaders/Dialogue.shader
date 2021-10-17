Shader "Custom/Dialogue" {    
    CGINCLUDE

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

        Pass {
            CGPROGRAM
            #pragma vertex vp
            #pragma fragment fp

            fixed4 fp(v2f i) : SV_TARGET {
                return 1.0f;
            }

            ENDCG
        }
    }
}
