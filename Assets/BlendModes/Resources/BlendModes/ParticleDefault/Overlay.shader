﻿Shader "BlendModes/ParticleDefault/Overlay" 
{
	Properties 
	{
		_Color ("Tint Color", Color) = (1,1,1,1)
		_MainTex ("Particle Texture", 2D) = "white" {}
        _OverlayTex("Overlay Texture", 2D) = "white" {}
        _OverlayColor("Overlay Color", Color) = (1,1,1,1)

	    [HideInInspector] _StencilRef ("Stencil Ref", Float) = 8
		[HideInInspector] _BlendStencilComp ("Blend Stencil Comp", Float) = 0
		[HideInInspector] _NormalStencilComp ("Normal Stencil Comp", Float) = 1
		[HideInInspector] _MaskStencilComp ("Mask Stencil Comp", Float) = 1
	}

	CGINCLUDE
	
	#include "UnityCG.cginc"
    #include "../BlendModes.cginc"
	
	sampler2D _MainTex;
	float4 _MainTex_ST;
	fixed4 _Color;
    sampler2D _OverlayTex;
    float4 _OverlayTex_ST;
    fixed4 _OverlayColor;
				
	struct VertexInput 
	{
		float4 Vertex : POSITION;
		fixed4 Color : COLOR;
		float2 TexCoord : TEXCOORD0;
        float2 OverlayTexCoord : TEXCOORD1;
	};

	struct VertexOutput 
	{
		float4 Vertex : SV_POSITION;
		fixed4 Color : COLOR;
		float2 TexCoord : TEXCOORD0;
        float2 OverlayTexCoord : TEXCOORD1;
	};

	VertexOutput ComputeVertex(VertexInput vertexInput)
	{
		VertexOutput vertexOutput;
					
		vertexOutput.Vertex = ObjectToClipPos(vertexInput.Vertex);
		vertexOutput.Color = vertexInput.Color;
		vertexOutput.TexCoord = TRANSFORM_TEX(vertexInput.TexCoord, _MainTex);
        vertexOutput.OverlayTexCoord = TRANSFORM_TEX(vertexInput.OverlayTexCoord, _OverlayTex);
					
		return vertexOutput;
	}
			
	ENDCG

	Category 
	{
		Tags 
		{ 
			"Queue" = "Transparent" 
			"IgnoreProjector" = "True" 
			"RenderType" = "Transparent" 
		}
		
		AlphaTest Greater .01
		ColorMask RGB
		Cull Off 
		Lighting Off 
		ZWrite Off 
		Fog { Color (0,0,0,0) }
		Blend SrcAlpha OneMinusSrcAlpha
		
		SubShader 
		{
			Pass 
			{
				Name "BlendEffect"

				Stencil
				{
					Ref [_StencilRef]
					Comp [_BlendStencilComp]
				}

				CGPROGRAM
			
				#pragma target 3.0				
				#pragma multi_compile BmDarken BmMultiply BmColorBurn BmLinearBurn BmDarkerColor BmLighten BmScreen BmColorDodge BmLinearDodge BmLighterColor BmOverlay BmSoftLight BmHardLight BmVividLight BmLinearLight BmPinLight BmHardMix BmDifference BmExclusion BmSubtract BmDivide BmHue BmSaturation BmColor BmLuminosity
				#pragma vertex ComputeVertex
				#pragma fragment ComputeFragment
				
				fixed4 ComputeFragment(VertexOutput vertexOutput) : SV_Target
				{
					fixed4 texColor = tex2D(_MainTex, vertexOutput.TexCoord) * vertexOutput.Color * _Color;
					fixed4 grabColor = tex2D(_OverlayTex, vertexOutput.OverlayTexCoord) * _OverlayColor;
					
					#include "../BlendOps.cginc"

                    blendResult = lerp(texColor, blendResult, grabColor.a);

					return blendResult;
				}
				
				ENDCG 
			}

			Pass 
			{  
				Name "NormalBlend"

				Stencil
				{
					Ref [_StencilRef]
					Comp [_NormalStencilComp]
				}

				CGPROGRAM
			
				#pragma vertex ComputeVertex
				#pragma fragment ComputeFragment
			
				fixed4 ComputeFragment(VertexOutput vertexOutput) : SV_Target
				{
					return tex2D(_MainTex, vertexOutput.TexCoord) * vertexOutput.Color * _Color;
				}
			
				ENDCG
			}

			Pass 
			{  
				Name "AutoMask"
				Colormask 0 
				ZWrite Off

				Stencil
				{
					Ref [_StencilRef]
					Comp [_MaskStencilComp]
					Pass Replace
				}

				CGPROGRAM
			
				#pragma vertex ComputeVertex
				#pragma fragment ComputeFragment
			
				fixed4 ComputeFragment(VertexOutput vertexOutput) : SV_Target
				{
					fixed4 texColor = tex2D(_MainTex, vertexOutput.TexCoord) * vertexOutput.Color * _Color;
					clip(texColor.a - .01);

					return texColor;
				}
			
				ENDCG
			}
		}	
	}
	
	FallBack "Particles/Additive"
	CustomEditor "BmMaterialEditor"
}
