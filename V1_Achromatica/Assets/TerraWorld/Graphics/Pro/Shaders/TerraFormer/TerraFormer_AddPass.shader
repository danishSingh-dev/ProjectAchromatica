Shader "Hidden/TerraUnity/TerraFormer_AddPass"
{
	Properties
	{
        // Used in fallback on old cards & base map
        [HideInInspector] _MainTex ("BaseMap (RGB)", 2D) = "white" {}
        [HideInInspector] _Color ("Main Color", Color) = (1,1,1,1)

		// Terrain data
		//_Control("AlphaMap", 2D) = "" {}
        //_Splat0 ("Layer 0 (R)", 2D) = "white" {}
        //_Splat1 ("Layer 1 (G)", 2D) = "white" {}
        //_Splat2 ("Layer 2 (B)", 2D) = "white" {}
        //_Splat3 ("Layer 3 (A)", 2D) = "white" {}
		//_Mask0("Mask 0 (R)", 2D) = "grey" {}
		//_Mask1("Mask 1 (G)", 2D) = "grey" {}
        //_Mask2("Mask 2 (B)", 2D) = "grey" {}
		//_Mask3("Mask 3 (A)", 2D) = "grey" {}
        //[Gamma] _Metallic0 ("Metallic 0", Range(0.0, 1.0)) = 0.0
        //[Gamma] _Metallic1 ("Metallic 1", Range(0.0, 1.0)) = 0.0
        //[Gamma] _Metallic2 ("Metallic 2", Range(0.0, 1.0)) = 0.0
        //[Gamma] _Metallic3 ("Metallic 3", Range(0.0, 1.0)) = 0.0
		//_Smoothness0 ("Smoothness 0", Range(0.0, 1.0)) = 1.0
		//_Smoothness1 ("Smoothness 1", Range(0.0, 1.0)) = 1.0
		//_Smoothness2 ("Smoothness 2", Range(0.0, 1.0)) = 1.0
		//_Smoothness3 ("Smoothness 3", Range(0.0, 1.0)) = 1.0
        //_DstBlend("DstBlend", Float) = 0.0

		// Maskmap textures with no sampler
		//_Maskmap0("Mask 0 (R)", 2D) = "grey" {}
		//_Maskmap1("Mask 1 (G)", 2D) = "grey" {}
        //_Maskmap2("Mask 2 (B)", 2D) = "grey" {}
		//_Maskmap3("Mask 3 (A)", 2D) = "grey" {}
		//_Maskmap4("Mask 4 (R)", 2D) = "grey" {}
		//_Maskmap5("Mask 5 (G)", 2D) = "grey" {}
        //_Maskmap6("Mask 6 (B)", 2D) = "grey" {}
		//_Maskmap7("Mask 7 (A)", 2D) = "grey" {}

		// Tessellation
		[Space(5)]
		[Header(Tessellation ________________________________________________________________________________________ )]
		[Space(5)]
		_EdgeLength("Tessellation Quality", Range(2, 64)) = 8
		_Phong ("Edge Smoothness", Range(0, 10)) = 1
		_Displacement1("Displacement 1", Range(0.1, 32.0)) = 0
		_Displacement2("Displacement 2", Range(0.1, 32.0)) = 0
		_Displacement3("Displacement 3", Range(0.1, 32.0)) = 0
		_Displacement4("Displacement 4", Range(0.1, 32.0)) = 0
		_Displacement5("Displacement 5", Range(0.1, 32.0)) = 0
		_Displacement6("Displacement 6", Range(0.1, 32.0)) = 0
		_Displacement7("Displacement 7", Range(0.1, 32.0)) = 0
		_Displacement8("Displacement 8", Range(0.1, 32.0)) = 0

		[Space(10)]
		[Header(Height Offset ________________________________________________________________________________________ )]
		[Space(5)]
		_HeightShift1("Height Offset 1", Range(0.1, 8)) = 0
		_HeightShift2("Height Offset 2", Range(0.1, 8)) = 0
		_HeightShift3("Height Offset 3", Range(0.1, 8)) = 0
		_HeightShift4("Height Offset 4", Range(0.1, 8)) = 0
		_HeightShift5("Height Offset 5", Range(0.1, 8)) = 0
		_HeightShift6("Height Offset 6", Range(0.1, 8)) = 0
		_HeightShift7("Height Offset 7", Range(0.1, 8)) = 0
		_HeightShift8("Height Offset 8", Range(0.1, 8)) = 0

		// Height Blending
		[Space(10)]
		[Header(Height Blending ________________________________________________________________________________________ )]
		[Space(5)]
		_HeightmapBlending("Heightmap Blending", Range(0.001, 1)) = 0.05

		// Tiling remover
		[Space(10)]
		[Header(Tiling Remover ________________________________________________________________________________________ )]
		[Space(5)]
		_TilingRemover1("Tiling Remover 1", Range(0, 64)) = 0
		_NoiseTiling1("Noise Tiling 1", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover2("Tiling Remover 2", Range(0, 64)) = 0
		_NoiseTiling2("Noise Tiling 2", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover3("Tiling Remover 3", Range(0, 64)) = 0
		_NoiseTiling3("Noise Tiling 3", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover4("Tiling Remover 4", Range(0, 64)) = 0
		_NoiseTiling4("Noise Tiling 4", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover5("Tiling Remover 5", Range(0, 64)) = 0
		_NoiseTiling5("Noise Tiling 5", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover6("Tiling Remover 6", Range(0, 64)) = 0
		_NoiseTiling6("Noise Tiling 6", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover7("Tiling Remover 7", Range(0, 64)) = 0
		_NoiseTiling7("Noise Tiling 7", Range(0, 1000)) = 100
		[Space(15)]
		_TilingRemover8("Tiling Remover 8", Range(0, 64)) = 0
		_NoiseTiling8("Noise Tiling 8", Range(0, 1000)) = 100

		// Layer colors
		[Space(10)]
		[Header(Layers ________________________________________________________________________________________ )]
		[Space(5)]
		_LightingColor ("Lighting", Color) = (1 ,1 ,1, 1)
		_LayerColor1 ("Color 1", Color) = (1 ,1 ,1, 1)
		_LayerColor2 ("Color 2", Color) = (1 ,1 ,1, 1)
		_LayerColor3 ("Color 3", Color) = (1 ,1 ,1, 1)
		_LayerColor4 ("Color 4", Color) = (1 ,1 ,1, 1)
		_LayerColor5 ("Color 5", Color) = (1 ,1 ,1, 1)
		_LayerColor6 ("Color 6", Color) = (1 ,1 ,1, 1)
		_LayerColor7 ("Color 7", Color) = (1 ,1 ,1, 1)
		_LayerColor8 ("Color 8", Color) = (1 ,1 ,1, 1)
		_LayerAO1 ("Ambient Occlusion 1", Range(0.0, 1.0)) = 1.0
		_LayerAO2 ("Ambient Occlusion 2", Range(0.0, 1.0)) = 1.0
		_LayerAO3 ("Ambient Occlusion 3", Range(0.0, 1.0)) = 1.0
		_LayerAO4 ("Ambient Occlusion 4", Range(0.0, 1.0)) = 1.0
		_LayerAO5 ("Ambient Occlusion 5", Range(0.0, 1.0)) = 1.0
		_LayerAO6 ("Ambient Occlusion 6", Range(0.0, 1.0)) = 1.0
		_LayerAO7 ("Ambient Occlusion 7", Range(0.0, 1.0)) = 1.0
		_LayerAO8 ("Ambient Occlusion 8", Range(0.0, 1.0)) = 1.0

		[Space(10)]
		[Header(Colormap Blending ________________________________________________________________________________________ )]
		[Space(5)]
		_ColorMap ("Colormap", 2D) = "gray" {}
		_BlendingDistance("Colormap Blending Distance", Float) = 10000
		_Blend ("Blending Range", Range (0, 1) ) = 0

		[Space(10)]
		[Header(Procedural Snow ________________________________________________________________________________________ )]
		[Space(5)]
		[Toggle] _ProceduralSnow("Procedural Snow", Float) = 1.0
        _SnowState("Snow Switch", Float) = 0.0
		_SnowDiffuse ("Diffuse", 2D) = "white" {}
		_SnowColor ("Color", Color) = (1, 1, 1, 1)
		_SnowTile ("Tiling", Float) = 2000
		_SnowAmount ("Amount", Range (0, 1) ) = 0.5
		_SnowAngle ("Angles", Range (-1, 1) ) = 0
		_NormalInfluence ("Normal Influence", Range (-1, 1) ) = 0
		_SnowStartHeight ("Start Height", Float) = 0
		_SnowPower("Power", Range(0.1, 2.0)) = 1.0
		_HeightFalloff ("Falloff",  Range (0, 10000) ) = 0
		_SnowSmoothness ("Smoothness", Range (0, 1) ) = 1
		_SnowThickness ("Thickness", Float) = 1
		_SnowDamping ("Damping", Float) = 1
		//_SnowNormalmap ("Normalmap", 2D) = "white" {}
		//_SnowNormalPower ("Normal Power", Range (0, 2) ) = 1
		//_SnowMaskmap ("Maskmap", 2D) = "white" {}
		//_SnowMetallic ("Metallic", Range (0, 1) ) = 0.1
		//_DisplacementSnow("Displacement", Range(1, 4.0)) = 2
		
		[Space(10)]
		[Header(Procedural Puddles ________________________________________________________________________________________ )]
		[Space(5)]
		_PuddleColor ("Color", Color) = (1,1,1,1)
		_Refraction("Refraction", Range(0, 1)) = 0.1
		_PuddleSmoothness("Smoothness", Range(0, 1)) = 1
		_PuddleMetallic("Metallic", Range(0, 1)) = 0.85
		_WaterHeight("Water Height", Range(0, 1)) = 0.85
		_Slope("Slope", Range(0, 0.3)) = 0.1
		_SlopeMin("Slope Min", Range(-0.1, 0.15)) = 0
		_Noise("Noise Texture", 2D) = "gray" {}
		_NoiseTiling("Noise Tiling", Float) = 10
		_NoiseIntensity("Noise Intensity", Range(0, 1)) = 0.8

		[Space(10)]
		[Header(Flat Shading ________________________________________________________________________________________ )]
		[Space(5)]
		[Toggle] _FlatShading("Flat Shading", Float) = 1.0
        _FlatShadingState("Flat Shading Switch", Float) = 0.0
		_FlatShadingStrengthTerrain("Vertex Displacement", Float) = 0.0
		_FlatShadingAngleMin("Min Slope", Float) = 0.0
		_FlatShadingAngleMax("Max Slope", Float) = 0.0

		//_WeightOpacity("Weight Opacity for the 2nd pass", Range(0, 1)) = 0.0

		// Water Mask
		_WaterMask ("Water Mask", 2D) = "black" {}
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Geometry-99"
            "IgnoreProjector"="True"
            "RenderType" = "Opaque"
			"MaskMapR" = "Metallic"
            "MaskMapG" = "AO"
            "MaskMapB" = "Height"
            "MaskMapA" = "Smoothness"
            "DiffuseA" = "Smoothness (becomes Density when Mask map is assigned)"   // when MaskMap is disabled
            "DiffuseA_MaskMapUsed" = "Density"                                      // when MaskMap is enabled
        }

        //Offset -0.2, -0.2

        //ZWrite Off
        //ZTest LEqual
        //ZTest Equal

        //Blend One One
        //Blend OneMinusDstColor One
        //Blend One OneMinusSrcAlpha
        //Blend SrcAlpha One

        //Blend OneMinusDstColor SrcColor
        //Blend OneMinusDstColor OneMinusSrcColor
        //Blend OneMinusDstColor DstColor
        //Blend SrcAlpha OneMinusSrcAlpha

        //AlphaToMask On

        //Tags { "Queue" = "Overlay" "IgnoreProjector"="True" "RenderType" = "Opaque" }
        

        CGPROGRAM
		#pragma surface surf Standard vertex:SplatmapVert finalcolor:SplatmapFinalColor finalgbuffer:SplatmapFinalGBuffer addshadow fullforwardshadows tessellate:tessEdge tessphong:_Phong noinstancing //nolightmap nodirlightmap nodynlightmap halfasview noforwardadd nometa //decal:add
        #pragma multi_compile_fog
		#pragma target 5.0

        // needs more than 8 texcoords
        #pragma exclude_renderers gles
        #include "UnityPBSLighting.cginc"

#if UNITY_VERSION >= 201930
		#pragma multi_compile_local __ _ALPHATEST_ON
#endif

		#pragma multi_compile __ _TESSELLATION
		#pragma multi_compile __ _HEIGHTMAPBLENDING
		#pragma multi_compile __ _COLORMAPBLENDING
		#pragma multi_compile __ _PROCEDURALSNOW
		#pragma multi_compile __ _PROCEDURALPUDDLES
		#pragma multi_compile __ _FLATSHADING

#ifdef _TESSELLATION
		#include "Tessellation.cginc"
		#include "TerraFormer_Tessellation.cginc"
#endif

		#include "TerraFormer_StochasticSampling.cginc"

#ifdef _HEIGHTMAPBLENDING
		#include "TerraFormer_HeightmapBlending.cginc"
#endif

#ifdef _COLORMAPBLENDING
		#include "TerraFormer_ColormapBlending.cginc"
#endif

#ifdef _PROCEDURALSNOW
		#include "TerraFormer_Snow.cginc"
#endif

#ifdef _PROCEDURALPUDDLES
		#include "TerraFormer_Puddles.cginc"
#endif

#ifdef _FLATSHADING
		#include "TerraFormer_FlatShading.cginc"
#endif

        #define TERRAIN_SPLAT_ADDPASS
        #define TERRAIN_STANDARD_SHADER
        #define TERRAIN_SURFACE_OUTPUT SurfaceOutputStandard

        #include "TerraFormer_SplatmapCommon_Add.cginc"

        ENDCG
    }

    Fallback "Hidden/TerrainEngine/Splatmap/Diffuse-AddPass"
}

