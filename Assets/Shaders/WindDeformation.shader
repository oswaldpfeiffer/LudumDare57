Shader "Custom/WindDeform_AlphaClip"
{
    Properties
    {
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
        _MainTex("Main Texture", 2D) = "white" {}
        _Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
        _WindStrength("Wind Strength", Float) = 0.2
        _WindSpeed("Wind Speed", Float) = 1.0
        _WindScale("Wind Scale", Float) = 1.0
        [Queue] _Queue("Render Queue", Float) = 2450
        [Offset] _OffsetFactor("Offset Factor", Float) = 0
        [Offset] _OffsetUnits("Offset Units", Float) = 0
    }

        SubShader
        {
            Tags {
                "RenderType" = "TransparentCutout"
                "Queue" = "AlphaTest"
            }
            LOD 200
            Offset[_OffsetFactor],[_OffsetUnits]

            Pass
            {
                Name "ForwardLit"
                Tags { "LightMode" = "UniversalForward" }

                HLSLPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

                struct Attributes
                {
                    float4 positionOS : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct Varyings
                {
                    float4 positionHCS : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                float4 _BaseColor;
                float _Cutoff;
                float _WindStrength;
                float _WindSpeed;
                float _WindScale;
                float _TimeOffset;

                TEXTURE2D(_MainTex);
                SAMPLER(sampler_MainTex);

                Varyings vert(Attributes v)
                {
                    Varyings o;

                    float3 worldPos = TransformObjectToWorld(v.positionOS.xyz);
                    float phase = sin(worldPos.x * _WindScale + (_Time.y + _TimeOffset) * _WindSpeed + worldPos.z);
                    float offset = phase * _WindStrength;

                    v.positionOS.xyz += float3(offset, 0, 0);
                    o.positionHCS = TransformObjectToHClip(v.positionOS);
                    o.uv = v.uv;
                    return o;
                }

                half4 frag(Varyings i) : SV_Target
                {
                    float4 tex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
                    clip(tex.a - _Cutoff);
                    return tex * _BaseColor;
                }
                ENDHLSL
            }
        }
}