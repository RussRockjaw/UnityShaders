Shader "Custom/Unlit/InvertedHullOutline"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,1,1,1) 
        _OutlineThickness ("Outline Thickness", float) = 1
    }
    SubShader
    {
        Tags {"RenderType"="Transparent" "Queue"="Transparent"}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                half4 normal : NORMAL;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
            };

            float4 _BaseColor;
            float _OutlineThickness;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = normalize(v.normal) * _OutlineThickness + v.vertex;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _BaseColor;
                return col;
            }
            ENDCG
        }
    }
}
