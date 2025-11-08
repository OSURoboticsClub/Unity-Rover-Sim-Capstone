Shader "Custom/TerrainHeightGradient" {
    Properties {
        _MainTex ("Terrain Texture", 2D) = "white" {}
        _MinHeight ("Minimum Height", Float) = 0.0
        _MaxHeight ("Maximum Height", Float) = 1.0
        _LowColor ("Low Height Color", Color) = (0,0,1,1)
        _MidColor ("Mid Height Color", Color) = (0,1,0,1)
        _HighColor ("High Height Color", Color) = (1,0,0,1)
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };

        half _Glossiness;
        half _Metallic;
        float _MinHeight;
        float _MaxHeight;
        fixed4 _LowColor;
        fixed4 _MidColor;
        fixed4 _HighColor;

        void surf (Input IN, inout SurfaceOutputStandard o) {
            // Get the world Y position (height)
            float height = IN.worldPos.y;
            
            // Normalize height between 0 and 1 based on min/max height
            float normalizedHeight = saturate((height - _MinHeight) / (_MaxHeight - _MinHeight));
            
            // Calculate the color based on height
            fixed4 color;
            if (normalizedHeight < 0.5) {
                // Interpolate between low and mid color
                color = lerp(_LowColor, _MidColor, normalizedHeight * 2);
            } else {
                // Interpolate between mid and high color
                color = lerp(_MidColor, _HighColor, (normalizedHeight - 0.5) * 2);
            }
            
            // Apply texture as a detail overlay
            fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = color.rgb * texColor.rgb;
            
            // Standard material properties
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = 1.0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
