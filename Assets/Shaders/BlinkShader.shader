Shader "Custom/BlinkSpriteURP"
{
    Properties
    {
        [MainTexture] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Color Tint", Color) = (1,1,1,1)
        _BlinkColor("Blink Color", Color) = (1,1,1,1)
        _BlinkAmount("Blink Amount", Range(0,1)) = 0
    }

        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
            LOD 100

            Pass
            {
                Name "BlinkSpritePass"
                Tags { "LightMode" = "UniversalForward" }

                Blend SrcAlpha OneMinusSrcAlpha
                Cull Off
                ZWrite Off

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

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;
                float4 _BlinkColor;
                float _BlinkAmount;

                Varyings vert(Attributes input)
                {
                    Varyings output;
                    output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                    output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                    return output;
                }

                half4 frag(Varyings input) : SV_Target
                {
                    half4 texColor = tex2D(_MainTex, input.uv) * _Color;
                    half4 blinkColor = lerp(texColor, _BlinkColor, _BlinkAmount);
                    return blinkColor;
                }
                ENDHLSL
            }
        }
}