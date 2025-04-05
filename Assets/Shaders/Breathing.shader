Shader "Unlit/BreathingSpriteTopOnly"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BreathSpeed("Breath Speed", Float) = 2.0
        _BreathStrength("Breath Strength", Float) = 0.05
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 100

            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
                Cull Off
                ZWrite Off

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float _BreathSpeed;
                float _BreathStrength;

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                v2f vert(appdata v)
                {
                    v2f o;

                    float breath = sin(_Time.y * _BreathSpeed) * _BreathStrength;

                    // We assume pivot is centered vertically (Y = 0 in middle of sprite)
                    // Only apply breathing if vertex is in the upper half (Y > 0)
                    float scale = (v.vertex.y > 0) ? (1.0 + breath) : 1.0;

                    float3 scaled = float3(v.vertex.x, v.vertex.y * scale, v.vertex.z);

                    o.vertex = UnityObjectToClipPos(float4(scaled, 1.0));
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    return tex2D(_MainTex, i.uv);
                }
                ENDCG
            }
        }
}