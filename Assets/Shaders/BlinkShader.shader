Shader "Custom/FlashEffectShader"
{
    Properties
    {
        _Color("Flash Color", Color) = (1, 1, 1, 1)
        _FlashIntensity("Flash Intensity", Range(0, 1)) = 0.0
        _MainTex("Base (RGB)", 2D) = "white" { }
    }
        SubShader
    {
        Tags { "Queue" = "Overlay" "RenderType" = "Opaque" }

        Pass
        {
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma multi_compile_fog
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            float _FlashIntensity;
            float4 _Color;

            // Structure d'entrée pour la passe
            struct Attributes
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // Structure de sortie pour la passe
            struct Varyings
            {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
            };

            // Fonction de vertex
            Varyings vert(Attributes v)
            {
                Varyings o;
                o.pos = TransformObjectToHClip(v.vertex.xyz);
                o.uv = v.uv;
                return o;
            }

            // Fonction de fragment (qui définit la couleur finale)
            half4 frag(Varyings i) : SV_Target
            {
                // Obtenir la couleur du sprite de base (la texture)
                half4 baseColor = tex2D(sampler_MainTex, i.uv);

                // Appliquer l'intensité du flash
                half flashEffect = _FlashIntensity;
                return baseColor * (1.0 - flashEffect) + _Color * flashEffect;
            }

            ENDHLSL
        }
    }

        FallBack "Diffuse"
}