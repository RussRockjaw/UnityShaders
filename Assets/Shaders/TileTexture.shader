Shader "Custom/Standard/TileTexture"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _UVs("UV Scale", float) = 1.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        float _UVs;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;
            float3 worldNormal;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float3 position = IN.worldPos / (-1.0 * abs(_UVs));
            float3 c00 = tex2D(_MainTex, IN.worldPos / 10);
            float3 c1= tex2D(_MainTex, position.yz).rgb;
            float3 c2 = tex2D(_MainTex, position.xz).rgb;
            float3 c3 = tex2D(_MainTex, position.xy).rgb;
            float alpha21 = abs(IN.worldNormal.x);
            float alpha23 = abs(IN.worldNormal.z);
            float3 c21 = lerp(c2, c1, alpha21).rgb;
            float3 c23 = lerp(c21, c3, alpha23).rgb;

            // Albedo comes from a texture tinted by color
            o.Albedo = c23;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
