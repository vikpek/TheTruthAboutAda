﻿Shader "Tessellation/Diffuse Bumped Specular Gloss AO" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
    _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
    _Parallax ("Height", Range (0.0, 1.0)) = 0.5
 
    _MainTex ("Base (RGB)", 2D) = "white" {}
    _GlossMap ("Glossmap (A)", 2D) = "gloss" {}
    _BumpMap ("Normalmap", 2D) = "bump" {}
    _ParallaxMap ("Heightmap (A)", 2D) = "black" {}
    _SpecMap ("Specular map", 2D) = "spec" {}
    _Occlusion ("Occlusion Map", 2D) = "white" {}
 
    _EdgeLength ("Edge length", Range(3,50)) = 10
}
SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 800
   
CGPROGRAM
#pragma surface surf BlinnPhong addshadow vertex:disp tessellate:tessEdge
#include "Tessellation.cginc"
 
struct appdata {
    float4 vertex : POSITION;
    float4 tangent : TANGENT;
    float3 normal : NORMAL;
    float2 texcoord : TEXCOORD0;
    float2 texcoord1 : TEXCOORD1;
};
 
float _EdgeLength;
float _Parallax;
 
float4 tessEdge (appdata v0, appdata v1, appdata v2)
{
    return UnityEdgeLengthBasedTessCull (v0.vertex, v1.vertex, v2.vertex, _EdgeLength, _Parallax * 1.5f);
}
 
sampler2D _ParallaxMap;
 
void disp (inout appdata v)
{
    float d = tex2Dlod(_ParallaxMap, float4(v.texcoord.xy,0,0)).a * _Parallax;
    v.vertex.xyz += v.normal * d;
}
 
sampler2D _MainTex;
sampler2D _BumpMap;
sampler2D _GlossMap;
sampler2D _SpecMap;
sampler2D _Occlusion;
fixed4 _Color;
half _Shininess;
 
struct Input {
    float2 uv_MainTex;
    float2 uv_BumpMap;
    float2 uv_GlossMap;
    float2 uv_SpecMap;
};
 
void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
    fixed4 gTex = tex2D(_GlossMap, IN.uv_GlossMap);
    fixed4 Occ = tex2D(_Occlusion, IN.uv_MainTex);
    fixed4 specTex = tex2D(_SpecMap, IN.uv_SpecMap);
    o.Albedo = tex.rgb * _Color.rgb * Occ.a;
    o.Gloss = gTex.a;
    o.Alpha = gTex.a * _Color.a;
    o.Specular = _Shininess * specTex.g;
    o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
}
ENDCG
}
 
FallBack "Bumped Specular"
}