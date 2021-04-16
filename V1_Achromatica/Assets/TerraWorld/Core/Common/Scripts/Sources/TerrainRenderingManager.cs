#if TERRAWORLD_PRO
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using TerraUnity.Runtime;
using TerraUnity.Utils;

namespace TerraUnity.Edittime
{
    public class TerrainRenderingManager
    {
        //private static RenderingParams _renderingParams = new RenderingParams(true);
        public static bool SplatmapResolutionBestFit { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapResolutionBestFit; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapResolutionBestFit = value; } }
        public static int SplatmapSmoothness { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapSmoothness; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapSmoothness = value; } }
        public static int SplatmapResolution { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapResolution; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.splatmapResolution = value; } }
        public static int TerrainPixelError { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.terrainPixelError; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.terrainPixelError = value; } }
        public static bool BGMountains { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGMountains; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGMountains = value; } }
        public static int BGTerrainScaleMultiplier { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainScaleMultiplier; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainScaleMultiplier = value; } }
        public static int BGTerrainHeightmapResolution { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainHeightmapResolution; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainHeightmapResolution = value; } }
        public static int BGTerrainSatelliteImageResolution { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainSatelliteImageResolution; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainSatelliteImageResolution = value; } }
        public static int BGTerrainPixelError { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainPixelError; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainPixelError = value; } }
        public static float BGTerrainOffset { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainOffset; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.BGTerrainOffset = value; } }
        public static string WorldName { get => TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.worldName; set { TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams.worldName = value; } }

        public static RenderingParams RenderingParams { get => GetRenderingParams(); set => SetRenderingParams(value); }

        public static Material TerrainMaterial { get => GetTerrainMaterial(); }

        public static Material TerrainMaterialBG { get => GetBGTerrainMaterial(); }

        public static Terrain WorldTerrain { get => GetMainTerrain(); }

        private static Texture2D colormapTexture;
        public static Texture2D ColormapTexture { get => GetColormapTexture(); set => SetColormapTexture(value); }
        private static Texture2D waterMaskTexture;
        public static Texture2D WaterMaskTexture { get => GetWaterMaskTexture(); set => SetWaterMaskTexture(value); }

        private static Texture2D snowTexture;
        public static Texture2D SnowTexture { get => GetSnowTexture(); }

        private static Texture2D noiseTexture;
        public static Texture2D NoiseTexture { get => GetNoiseTexture(); }

        private static int terrainLayersCount;
        public static int TerrainLayersCount { get => GetTerrainLayersCount(); }

        public static bool isModernRendering { get => IsModernRendering(); set { SetModernRendering(value); } }
        public static bool isTessellated { get => IsTerrainTessellation(); set { SetTerrainTessellation(value); } }
        public static bool isHeightmapBlending { get => IsTerrainHeightmapBlending(); set { SetTerrainHeightmapBlending(value); } }
        public static bool isColormapBlending { get => IsTerrainColormapBlending(); set { SetTerrainColormapBlending(value); } }
        public static bool isProceduralSnow { get => IsTerrainProceduralSnow(); set { SetTerrainProceduralSnow(value); } }
        public static bool isProceduralSnowBG { get => IsTerrainProceduralSnowBG(); set { SetTerrainProceduralSnowBG(value); } }
        public static bool isFlatShading { get => IsTerrainFlatShading(); set { SetTerrainFlatShading(value); } }
        public static bool isProceduralPuddles { get => IsTerrainProceduralPuddles(); set { SetTerrainProceduralPuddles(value); } }

        public static Color LightingColor { get => GetColor("_LightingColor"); set { SetColor("_LightingColor", value); } }
        public static Color LightingColorBG { get => GetColorBG("_LightingColor"); set { SetColorBG("_LightingColor", value); } }
        public static Color SnowColor { get => GetColor("_SnowColor"); set { SetColor("_SnowColor", value); } }
        public static Color PuddleColor { get => GetColor("_PuddleColor"); set { SetColor("_PuddleColor", value); } }
        public static float HeightmapBlending { get => GetFloat("_HeightmapBlending"); set { SetFloat("_HeightmapBlending", value); } }
        public static float BlendingDistance { get => GetFloat("_BlendingDistance"); set { SetFloat("_BlendingDistance", value); } }
        public static float SnowTile { get => GetFloat("_SnowTile"); set { SetFloat("_SnowTile", value); } }
        public static float SnowAmount { get => GetFloat("_SnowAmount"); set { SetFloat("_SnowAmount", value); } }
        public static float SnowAngle { get => GetFloat("_SnowAngle"); set { SetFloat("_SnowAngle", value); } }
        public static float SnowNormalInfluence { get => GetFloat("_NormalInfluence"); set { SetFloat("_NormalInfluence", value); } }
        public static float SnowPower { get => GetFloat("_SnowPower"); set { SetFloat("_SnowPower", value); } }
        public static float SnowSmoothness { get => GetFloat("_SnowSmoothness"); set { SetFloat("_SnowSmoothness", value); } }
        public static float PuddleRefraction { get => GetFloat("_Refraction"); set { SetFloat("_Refraction", value); } }
        public static float PuddleMetallic { get => GetFloat("_PuddleMetallic"); set { SetFloat("_PuddleMetallic", value); } }
        public static float PuddleSmoothness { get => GetFloat("_PuddleSmoothness"); set { SetFloat("_PuddleSmoothness", value); } }
        public static float PuddleSlope { get => GetFloat("_Slope"); set { SetFloat("_Slope", value); } }
        public static float PuddleSlopeMin { get => GetFloat("_SlopeMin"); set { SetFloat("_SlopeMin", value); } }
        public static float PuddleNoiseTiling { get => GetFloat("_NoiseTiling"); set { SetFloat("_NoiseTiling", value); } }
        public static float PuddlewaterHeight { get => GetFloat("_WaterHeight"); set { SetFloat("_WaterHeight", value); } }
        public static float PuddleNoiseInfluence { get => GetFloat("_NoiseIntensity"); set { SetFloat("_NoiseIntensity", value); } }
        public static float SnowStartHeight { get => GetFloat("_SnowStartHeight"); set { SetFloat("_SnowStartHeight", value); SetFloatBG("_SnowStartHeight", value); } }
        public static float HeightFalloff { get => GetFloat("_HeightFalloff"); set { SetFloat("_HeightFalloff", value); SetFloatBG("_HeightFalloff", value); } }
        public static float SnowThickness { get => GetFloat("_SnowThickness"); set { SetFloat("_SnowThickness", value); SetFloatBG("_SnowThickness", value); } }
        public static float SnowDamping { get => GetFloat("_SnowDamping"); set { SetFloat("_SnowDamping", value); SetFloatBG("_SnowDamping", value); } }

        public static Color GetColorBG(string variable)
        {
            if (TerrainMaterialBG != null && TerrainMaterialBG.HasProperty(variable))
                return TerrainMaterialBG.GetColor(variable);
            else
                return new Color(1,1,1);
        }

        public static void SetColorBG(string variable, Color value)
        {
            if (!isModernRendering) return;

            if (TerrainMaterialBG != null && TerrainMaterialBG.HasProperty(variable))
                TerrainMaterialBG.SetColor(variable, value);
        }

        public static float TessellationQuality
        {
            get
            {
                if (!isTessellated) return 0;
                return GetFloat("_EdgeLength");
            }
            set
            {
                if (isTessellated)
                    SetFloat("_EdgeLength", value);
            }
        }

        public static float EdgeSmoothness
        {
            get
            {
                if (!isTessellated) return 0;
                return GetFloat("_Phong");
            }
            set
            {
                if (isTessellated)
                    SetFloat("_Phong", value);
            }
        }

        public static float GetFloat(string variable)
        {
            if (isModernRendering && TerrainMaterial.HasProperty(variable))
                return TerrainMaterial.GetFloat(variable);
            else
                return 0;
        }

        public static void SetFloat(string variable, float value)
        {
            if (isModernRendering)
            {
                if (TerrainMaterial.HasProperty(variable))
                    TerrainMaterial.SetFloat(variable, value);
            }
        }

        public static float GetFloatBG(string variable)
        {
            if (isModernRendering && TerrainMaterialBG != null && TerrainMaterialBG.HasProperty(variable))
                return TerrainMaterialBG.GetFloat(variable);
            else
                return 0;
        }

        public static void SetFloatBG(string variable, float value)
        {
            if (isModernRendering)
            {
                if (TerrainMaterialBG != null && TerrainMaterialBG.HasProperty(variable))
                    TerrainMaterialBG.SetFloat(variable, value);
            }
        }

        public static Color GetColor(string variable)
        {
            if (isModernRendering && TerrainMaterial.HasProperty(variable))
                return TerrainMaterial.GetColor(variable);
            else
                return new Color(1, 1, 1);
        }

        public static void SetColor(string variable, Color value)
        {
            if (isModernRendering && TerrainMaterial.HasProperty(variable))
                TerrainMaterial.SetColor(variable, value);
        }

        public static float GetDisplacement(int index)
        {
            if (!isTessellated) return 0;
            return GetFloat("_Displacement" + (index + 1).ToString());
        }

        public static void SetDisplacement(int index, float value)
        {
            if (isTessellated)
                SetFloat("_Displacement" + (index + 1).ToString(), value);
        }

        public static float GetHeightOffset(int index)
        {
            if (!isTessellated) return 0;
            return GetFloat("_HeightShift" + (index + 1).ToString());
        }

        public static void SetHeightOffset(int index, float value)
        {
            if (isTessellated)
                SetFloat("_HeightShift" + (index + 1).ToString(), value);
        }

        public static float GetTileRemover(int index)
        {
            return GetFloat("_TilingRemover" + (index + 1).ToString());
        }

        public static void SetTileRemover(int index, float value)
        {

            SetFloat("_TilingRemover" + (index + 1).ToString(), value);
        }

        public static float GetNoiseTiling(int index)
        {
            return GetFloat("_NoiseTiling" + (index + 1).ToString());
        }

        public static void SetNoseTiling(int index, float value)
        {
            SetFloat("_NoiseTiling" + (index + 1).ToString(), value);
        }

        public static Color GetLayerColor(int index)
        {
            return GetColor("_LayerColor" + (index + 1).ToString());
        }

        public static void SetLayerColor(int index, Color value)
        {
            SetColor("_LayerColor" + (index + 1).ToString(), value);
        }

        public static float GetLayerAO(int index)
        {
            return GetFloat("_LayerAO" + (index + 1).ToString());
        }

        public static void SetLayerAO(int index, float value)
        {
            SetFloat("_LayerAO" + (index + 1).ToString(), value);
        }

        public static void Reset()
        {
            TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams = new RenderingParams(true);
            RenderingParams = TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams;
        }

        private static RenderingParams GetRenderingParams()
        {
            RenderingParams _renderingParams = TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams;
            if (TerrainMaterial == null)
                return _renderingParams;
            else
            {
#pragma warning disable IDE0017 // Simplify object initialization
                RenderingParams renderingParams = new RenderingParams(true);
#pragma warning restore IDE0017 // Simplify object initialization
                renderingParams.modernRendering = isModernRendering;

                if (isModernRendering)
                {
                    renderingParams.worldName = WorldName;

                    renderingParams.tessellation = isTessellated;
                    renderingParams.heightmapBlending = isHeightmapBlending;
                    renderingParams.colormapBlending = isColormapBlending;
                    renderingParams.proceduralSnow = isProceduralSnow;
                    renderingParams.proceduralPuddles = isProceduralPuddles;
                    renderingParams.isFlatShading = isFlatShading;

                    renderingParams.surfaceTintColorMAIN = TUtils.UnityColorToVector4(LightingColor);
                    renderingParams.surfaceTintColorBG = TUtils.UnityColorToVector4(LightingColorBG);

                    renderingParams.tessellationQuality = TessellationQuality;
                    renderingParams.edgeSmoothness = EdgeSmoothness;

                    renderingParams.displacement1 = GetDisplacement(0);
                    renderingParams.displacement2 = GetDisplacement(1);
                    renderingParams.displacement3 = GetDisplacement(2);
                    renderingParams.displacement4 = GetDisplacement(3);
                    renderingParams.displacement5 = GetDisplacement(4);
                    renderingParams.displacement6 = GetDisplacement(5);
                    renderingParams.displacement7 = GetDisplacement(6);
                    renderingParams.displacement8 = GetDisplacement(7);

                    renderingParams.heightOffset1 = GetHeightOffset(0);
                    renderingParams.heightOffset2 = GetHeightOffset(1);
                    renderingParams.heightOffset3 = GetHeightOffset(2);
                    renderingParams.heightOffset4 = GetHeightOffset(3);
                    renderingParams.heightOffset5 = GetHeightOffset(4);
                    renderingParams.heightOffset6 = GetHeightOffset(5);
                    renderingParams.heightOffset7 = GetHeightOffset(6);
                    renderingParams.heightOffset8 = GetHeightOffset(7);

                    renderingParams.heightBlending = HeightmapBlending;

                    renderingParams.tilingRemover1 = GetTileRemover(0);
                    renderingParams.tilingRemover2 = GetTileRemover(1);
                    renderingParams.tilingRemover3 = GetTileRemover(2);
                    renderingParams.tilingRemover4 = GetTileRemover(3);
                    renderingParams.tilingRemover5 = GetTileRemover(4);
                    renderingParams.tilingRemover6 = GetTileRemover(5);
                    renderingParams.tilingRemover7 = GetTileRemover(6);
                    renderingParams.tilingRemover8 = GetTileRemover(7);

                    renderingParams.noiseTiling1 = GetNoiseTiling(0);
                    renderingParams.noiseTiling2 = GetNoiseTiling(1);
                    renderingParams.noiseTiling3 = GetNoiseTiling(2);
                    renderingParams.noiseTiling4 = GetNoiseTiling(3);
                    renderingParams.noiseTiling5 = GetNoiseTiling(4);
                    renderingParams.noiseTiling6 = GetNoiseTiling(5);
                    renderingParams.noiseTiling7 = GetNoiseTiling(6);
                    renderingParams.noiseTiling8 = GetNoiseTiling(7);

                    renderingParams.colormapBlendingDistance = BlendingDistance;
                    renderingParams.colormapBlendingRange = 0.0f;

                    renderingParams.snowColorR = SnowColor.r;
                    renderingParams.snowColorG = SnowColor.g;
                    renderingParams.snowColorB = SnowColor.b;
                    renderingParams.snowTiling = SnowTile;
                    renderingParams.snowAmount = SnowAmount;
                    renderingParams.snowAngles = SnowAngle;
                    renderingParams.snowNormalInfluence = SnowNormalInfluence;
                    renderingParams.snowPower = SnowPower;
                    renderingParams.snowSmoothness = SnowSmoothness;
                    renderingParams.snowStartHeight = SnowStartHeight;
                    renderingParams.heightFalloff = HeightFalloff;

                    renderingParams.puddleColorR = PuddleColor.r;
                    renderingParams.puddleColorG = PuddleColor.g;
                    renderingParams.puddleColorB = PuddleColor.b;
                    renderingParams.puddleRefraction = PuddleRefraction;
                    renderingParams.puddleMetallic = PuddleMetallic;
                    renderingParams.puddleSmoothness = PuddleSmoothness;
                    renderingParams.puddlewaterHeight = PuddlewaterHeight;
                    renderingParams.puddleSlope = PuddleSlope;
                    renderingParams.puddleMinSlope = PuddleSlopeMin;
                    renderingParams.puddleNoiseTiling = PuddleNoiseTiling;
                    renderingParams.puddleNoiseInfluence = PuddleNoiseInfluence;
                    //renderingParams.puddleReflections = PuddleReflections;

                    renderingParams.layerColor1R = GetLayerColor(0).r;
                    renderingParams.layerColor1G = GetLayerColor(0).g;
                    renderingParams.layerColor1B = GetLayerColor(0).b;
                    renderingParams.layerColor2R = GetLayerColor(1).r;
                    renderingParams.layerColor2G = GetLayerColor(1).g;
                    renderingParams.layerColor2B = GetLayerColor(1).b;
                    renderingParams.layerColor3R = GetLayerColor(2).r;
                    renderingParams.layerColor3G = GetLayerColor(2).g;
                    renderingParams.layerColor3B = GetLayerColor(2).b;
                    renderingParams.layerColor4R = GetLayerColor(3).r;
                    renderingParams.layerColor4G = GetLayerColor(3).g;
                    renderingParams.layerColor4B = GetLayerColor(3).b;
                    renderingParams.layerColor5R = GetLayerColor(4).r;
                    renderingParams.layerColor5G = GetLayerColor(4).g;
                    renderingParams.layerColor5B = GetLayerColor(4).b;
                    renderingParams.layerColor6R = GetLayerColor(5).r;
                    renderingParams.layerColor6G = GetLayerColor(5).g;
                    renderingParams.layerColor6B = GetLayerColor(5).b;
                    renderingParams.layerColor7R = GetLayerColor(6).r;
                    renderingParams.layerColor7G = GetLayerColor(6).g;
                    renderingParams.layerColor7B = GetLayerColor(6).b;
                    renderingParams.layerColor8R = GetLayerColor(7).r;
                    renderingParams.layerColor8G = GetLayerColor(7).g;
                    renderingParams.layerColor8B = GetLayerColor(7).b;
                    renderingParams.layerAO1 = GetLayerAO(0);
                    renderingParams.layerAO2 = GetLayerAO(1);
                    renderingParams.layerAO3 = GetLayerAO(2);
                    renderingParams.layerAO4 = GetLayerAO(3);
                    renderingParams.layerAO5 = GetLayerAO(4);
                    renderingParams.layerAO6 = GetLayerAO(5);
                    renderingParams.layerAO7 = GetLayerAO(6);
                    renderingParams.layerAO8 = GetLayerAO(7);
                }

                renderingParams.splatmapResolutionBestFit = SplatmapResolutionBestFit;
                renderingParams.splatmapSmoothness = SplatmapSmoothness;
                renderingParams.splatmapResolution = SplatmapResolution;
                renderingParams.terrainPixelError = TerrainPixelError;
                renderingParams.BGMountains = BGMountains;
                renderingParams.BGTerrainScaleMultiplier = BGTerrainScaleMultiplier;
                renderingParams.BGTerrainHeightmapResolution = BGTerrainHeightmapResolution;
                renderingParams.BGTerrainSatelliteImageResolution = BGTerrainSatelliteImageResolution;
                renderingParams.BGTerrainPixelError = BGTerrainPixelError;
                renderingParams.BGTerrainOffset = BGTerrainOffset;

                TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams = _renderingParams;

                return renderingParams;
            }
        }

        private static void SetRenderingParams(RenderingParams renderingParams)
        {
            TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams = renderingParams;
            ApplyRenderingParams();
        }

        public static void ApplyRenderingParams()
        {
            if (TerrainMaterial == null)
                return;

            RenderingParams _renderingParams = TTerraWorld.WorldGraph.renderingGraph.GetEntryNode().renderingParams;

            isModernRendering = _renderingParams.modernRendering;

            if (_renderingParams.modernRendering)
            {
                WorldName = _renderingParams.worldName;

                isTessellated = _renderingParams.tessellation;
                isHeightmapBlending = _renderingParams.heightmapBlending;
                isColormapBlending = _renderingParams.colormapBlending;
                isProceduralSnow = _renderingParams.proceduralSnow;
                isProceduralPuddles = _renderingParams.proceduralPuddles;
                isFlatShading = _renderingParams.isFlatShading;

                LightingColor = TUtils.Vector4ToUnityColor(_renderingParams.surfaceTintColorMAIN);
                if (TTerraWorldManager.BackgroundTerrainGO != null)
                    LightingColorBG = TUtils.Vector4ToUnityColor(_renderingParams.surfaceTintColorBG);

                TessellationQuality = _renderingParams.tessellationQuality;
                EdgeSmoothness = _renderingParams.edgeSmoothness;

                SetDisplacement(0, _renderingParams.displacement1);
                SetDisplacement(1, _renderingParams.displacement2);
                SetDisplacement(2, _renderingParams.displacement3);
                SetDisplacement(3, _renderingParams.displacement4);
                SetDisplacement(4, _renderingParams.displacement5);
                SetDisplacement(5, _renderingParams.displacement6);
                SetDisplacement(6, _renderingParams.displacement7);
                SetDisplacement(7, _renderingParams.displacement8);

                SetHeightOffset(0, _renderingParams.heightOffset1);
                SetHeightOffset(1, _renderingParams.heightOffset2);
                SetHeightOffset(2, _renderingParams.heightOffset3);
                SetHeightOffset(3, _renderingParams.heightOffset4);
                SetHeightOffset(4, _renderingParams.heightOffset5);
                SetHeightOffset(5, _renderingParams.heightOffset6);
                SetHeightOffset(6, _renderingParams.heightOffset7);
                SetHeightOffset(7, _renderingParams.heightOffset8);

                HeightmapBlending = _renderingParams.heightBlending;

                SetTileRemover(0, _renderingParams.tilingRemover1);
                SetTileRemover(1, _renderingParams.tilingRemover2);
                SetTileRemover(2, _renderingParams.tilingRemover3);
                SetTileRemover(3, _renderingParams.tilingRemover4);
                SetTileRemover(4, _renderingParams.tilingRemover5);
                SetTileRemover(5, _renderingParams.tilingRemover6);
                SetTileRemover(6, _renderingParams.tilingRemover7);
                SetTileRemover(7, _renderingParams.tilingRemover8);

                SetNoseTiling(0, _renderingParams.noiseTiling1);
                SetNoseTiling(1, _renderingParams.noiseTiling2);
                SetNoseTiling(2, _renderingParams.noiseTiling3);
                SetNoseTiling(3, _renderingParams.noiseTiling4);
                SetNoseTiling(4, _renderingParams.noiseTiling5);
                SetNoseTiling(5, _renderingParams.noiseTiling6);
                SetNoseTiling(6, _renderingParams.noiseTiling7);
                SetNoseTiling(7, _renderingParams.noiseTiling8);

                BlendingDistance = _renderingParams.colormapBlendingDistance;

                SnowColor = new Color(_renderingParams.snowColorR, _renderingParams.snowColorG, _renderingParams.snowColorB);

                SnowTile = _renderingParams.snowTiling;
                SnowAmount = _renderingParams.snowAmount;
                SnowAngle = _renderingParams.snowAngles;
                SnowNormalInfluence = _renderingParams.snowNormalInfluence;
                SnowPower = _renderingParams.snowPower;
                SnowSmoothness = _renderingParams.snowSmoothness;
                SnowStartHeight = _renderingParams.snowStartHeight;
                HeightFalloff = _renderingParams.heightFalloff;

                PuddleColor = new Color(_renderingParams.puddleColorR, _renderingParams.puddleColorG, _renderingParams.puddleColorB);

                PuddleRefraction = _renderingParams.puddleRefraction;
                PuddleMetallic = _renderingParams.puddleMetallic;
                PuddleSmoothness = _renderingParams.puddleSmoothness;
                PuddlewaterHeight = _renderingParams.puddlewaterHeight;
                PuddleSlope = _renderingParams.puddleSlope;
                PuddleSlopeMin = _renderingParams.puddleMinSlope;
                PuddleNoiseTiling = _renderingParams.puddleNoiseTiling;
                PuddleNoiseInfluence = _renderingParams.puddleNoiseInfluence;
                //PuddleReflections = _renderingParams.puddleReflections;

                SetLayerColor(0, new Color(_renderingParams.layerColor1R, _renderingParams.layerColor1G, _renderingParams.layerColor1B));
                SetLayerColor(1, new Color(_renderingParams.layerColor2R, _renderingParams.layerColor2G, _renderingParams.layerColor2B));
                SetLayerColor(2, new Color(_renderingParams.layerColor3R, _renderingParams.layerColor3G, _renderingParams.layerColor3B));
                SetLayerColor(3, new Color(_renderingParams.layerColor4R, _renderingParams.layerColor4G, _renderingParams.layerColor4B));
                SetLayerColor(4, new Color(_renderingParams.layerColor5R, _renderingParams.layerColor5G, _renderingParams.layerColor5B));
                SetLayerColor(5, new Color(_renderingParams.layerColor6R, _renderingParams.layerColor6G, _renderingParams.layerColor6B));
                SetLayerColor(6, new Color(_renderingParams.layerColor7R, _renderingParams.layerColor7G, _renderingParams.layerColor7B));
                SetLayerColor(7, new Color(_renderingParams.layerColor8R, _renderingParams.layerColor8G, _renderingParams.layerColor8B));

                SetLayerAO(0, _renderingParams.layerAO1);
                SetLayerAO(1, _renderingParams.layerAO2);
                SetLayerAO(2, _renderingParams.layerAO3);
                SetLayerAO(3, _renderingParams.layerAO4);
                SetLayerAO(4, _renderingParams.layerAO5);
                SetLayerAO(5, _renderingParams.layerAO6);
                SetLayerAO(6, _renderingParams.layerAO7);
                SetLayerAO(7, _renderingParams.layerAO8);
            }

            SplatmapResolutionBestFit = _renderingParams.splatmapResolutionBestFit;
            SplatmapSmoothness = _renderingParams.splatmapSmoothness;
            SplatmapResolution = _renderingParams.splatmapResolution;

            TerrainPixelError = _renderingParams.terrainPixelError;

            BGMountains = _renderingParams.BGMountains;
            BGTerrainScaleMultiplier = _renderingParams.BGTerrainScaleMultiplier;
            BGTerrainHeightmapResolution = _renderingParams.BGTerrainHeightmapResolution;
            BGTerrainSatelliteImageResolution = _renderingParams.BGTerrainSatelliteImageResolution;
            BGTerrainPixelError = _renderingParams.BGTerrainPixelError;
            BGTerrainOffset = _renderingParams.BGTerrainOffset;
        }

        private static Terrain GetMainTerrain()
        {
            if (TTerraWorldManager.MainTerrainGO == null)
                throw new Exception("No Terrains Found!");

            return TTerraWorldManager.TerrainParamsScript.MainTerrain;
        }

        private static Material GetTerrainMaterial()
        {
            if (TTerraWorldManager.MainTerrainGO != null)
                return TTerraWorldManager.TerrainParamsScript.TerrainMaterial;
            else
                return null;
        }

        private static Material GetBGTerrainMaterial()
        {
            if (TTerraWorldManager.BackgroundTerrainGO != null)
                return TTerraWorldManager.TerrainParamsScript.TerrainMaterialBG;
            else
                return null;
        }

        private static bool IsModernRendering()
        {
            if (TerrainMaterial == null || !TerrainMaterial.HasProperty("_SnowThickness"))
                return false;
            else if (TerrainMaterial.shader == Shader.Find("TerraUnity/TerraFormer") || TerrainMaterial.shader == Shader.Find("TerraUnity/TerraFormer Instanced"))
                return true;
            else
                return false;
        }

        private static void SetModernRendering(bool isModernRendering)
        {
            if (TerrainMaterial == null) return;

            if (isModernRendering)
            {
                TerrainMaterial.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
                //SetTerrainMaterialTerraFormer();
            }
            else
            {
                //SetTerrainMaterialStandard();
                TerrainMaterial.shader = Shader.Find("Nature/Terrain/Standard");
            }

            if (TerrainMaterialBG == null) return;

            if (isModernRendering)
            {
                TerrainMaterialBG.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
                //SetTerrainMaterialTerraFormer();
            }
            else
            {
                //SetTerrainMaterialStandard();
                TerrainMaterialBG.shader = Shader.Find("Nature/Terrain/Standard");
            }
        }

        private static bool IsTerrainTessellation()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.shader == Shader.Find("TerraUnity/TerraFormer") && TerrainMaterial.IsKeywordEnabled("_TESSELLATION"))
                return true;
            else
                return false;
        }

        private static void SetTerrainTessellation(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
            {
                TerrainMaterial.shader = Shader.Find("TerraUnity/TerraFormer");
                TerrainMaterial.EnableKeyword("_TESSELLATION");
                WorldTerrain.drawInstanced = false;
            }
            else
            {
                TerrainMaterial.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
                WorldTerrain.drawInstanced = true;
            }
        }

        private static bool IsTerrainHeightmapBlending()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.IsKeywordEnabled("_HEIGHTMAPBLENDING"))
                return true;
            else
                return false;
        }

        private static void SetTerrainHeightmapBlending(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
                TerrainMaterial.EnableKeyword("_HEIGHTMAPBLENDING");
            else
                TerrainMaterial.DisableKeyword("_HEIGHTMAPBLENDING");
        }

        private static bool IsTerrainColormapBlending()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.IsKeywordEnabled("_COLORMAPBLENDING"))
                return true;
            else
                return false;
        }

        private static void SetTerrainColormapBlending(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
                TerrainMaterial.EnableKeyword("_COLORMAPBLENDING");
            else
                TerrainMaterial.DisableKeyword("_COLORMAPBLENDING");
        }

        private static bool IsTerrainProceduralSnow()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.IsKeywordEnabled("_PROCEDURALSNOW"))
                return true;
            else
                return false;
        }

        private static void SetTerrainProceduralSnow(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
            {
                TerrainMaterial.EnableKeyword("_PROCEDURALSNOW");
                TerrainMaterial.SetFloat("_SnowState", 1);
            }
            else
            {
                TerrainMaterial.DisableKeyword("_PROCEDURALSNOW");
                TerrainMaterial.SetFloat("_SnowState", 0);
            }

            SetTerrainProceduralSnowBG(enabled);
        }

        private static bool IsTerrainProceduralSnowBG()
        {
            if (TerrainMaterialBG == null) return false;

            if (TerrainMaterialBG.IsKeywordEnabled("_PROCEDURALSNOW"))
                return true;
            else
                return false;
        }

        private static void SetTerrainProceduralSnowBG(bool enabled)
        {
            if (TerrainMaterialBG == null || !isModernRendering) return;

            if (enabled)
            {
                TerrainMaterialBG.EnableKeyword("_PROCEDURALSNOW");
                TerrainMaterialBG.SetFloat("_SnowState", 1);

                TerrainMaterialBG.SetColor("_SnowColor", TerrainMaterial.GetColor("_SnowColor"));
                TerrainMaterialBG.SetFloat("_SnowTile", TerrainMaterial.GetFloat("_SnowTile"));
                TerrainMaterialBG.SetFloat("_SnowAmount", TerrainMaterial.GetFloat("_SnowAmount"));
                TerrainMaterialBG.SetFloat("_SnowAngle", TerrainMaterial.GetFloat("_SnowAngle"));
                TerrainMaterialBG.SetFloat("_NormalInfluence", TerrainMaterial.GetFloat("_NormalInfluence"));
                TerrainMaterialBG.SetFloat("_SnowPower", TerrainMaterial.GetFloat("_SnowPower"));
                TerrainMaterialBG.SetFloat("_SnowSmoothness", TerrainMaterial.GetFloat("_SnowSmoothness"));
                //TerrainMaterialBG.SetFloat("_SnowMetallic", TerrainMaterial.GetFloat("_SnowMetallic"));
            }
            else
            {
                TerrainMaterialBG.DisableKeyword("_PROCEDURALSNOW");
                TerrainMaterialBG.SetFloat("_SnowState", 0);
            }
        }

        private static bool IsTerrainFlatShading()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.IsKeywordEnabled("_FLATSHADING"))
                return true;
            else
                return false;
        }

        private static void SetTerrainFlatShading(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
            {
                TerrainMaterial.EnableKeyword("_FLATSHADING");
                TerrainMaterial.SetFloat("_FlatShadingState", 1);
            }
            else
            {
                TerrainMaterial.DisableKeyword("_FLATSHADING");
                TerrainMaterial.SetFloat("_FlatShadingState", 0);
            }

            SetTerrainFlatShadingBG(enabled);
        }

        private static void SetTerrainFlatShadingBG(bool enabled)
        {
            if (TerrainMaterialBG == null) return;

            if (enabled)
            {
                TerrainMaterialBG.EnableKeyword("_FLATSHADING");
                TerrainMaterialBG.SetFloat("_FlatShadingState", 1);
            }
            else
            {
                TerrainMaterialBG.DisableKeyword("_FLATSHADING");
                TerrainMaterialBG.SetFloat("_FlatShadingState", 0);
            }
        }

        private static bool IsTerrainProceduralPuddles()
        {
            if (!isModernRendering) return false;

            if (TerrainMaterial.IsKeywordEnabled("_PROCEDURALPUDDLES"))
                return true;
            else
                return false;
        }

        private static void SetTerrainProceduralPuddles(bool enabled)
        {
            if (!isModernRendering) return;

            if (enabled)
                TerrainMaterial.EnableKeyword("_PROCEDURALPUDDLES");
            else
                TerrainMaterial.DisableKeyword("_PROCEDURALPUDDLES");
        }

        private static Texture2D GetColormapTexture()
        {
            if (!isModernRendering) colormapTexture = null;

            if (colormapTexture == null)
                colormapTexture = TerrainMaterial.GetTexture("_ColorMap") as Texture2D;

            if (colormapTexture == null)
                TerrainMaterial.DisableKeyword("_COLORMAPBLENDING");

            return colormapTexture;
        }

        private static void SetColormapTexture(Texture2D texture2D)
        {
            colormapTexture = texture2D;
            TerrainMaterial.SetTexture("_ColorMap", texture2D);

            if (colormapTexture == null)
                TerrainMaterial.DisableKeyword("_COLORMAPBLENDING");
        }

        private static Texture2D GetWaterMaskTexture()
        {
            if (!isModernRendering) waterMaskTexture = null;

            if (waterMaskTexture == null)
                waterMaskTexture = TerrainMaterial.GetTexture("_WaterMask") as Texture2D;

            return waterMaskTexture;
        }

        private static void SetWaterMaskTexture(Texture2D texture2D)
        {
            waterMaskTexture = texture2D;
            TerrainMaterial.SetTexture("_WaterMask", texture2D);
        }

        private static Texture2D GetSnowTexture()
        {
            if (!isModernRendering) snowTexture = null;
            else snowTexture = TerrainMaterial.GetTexture("_SnowDiffuse") as Texture2D;
            return snowTexture;
        }

        private static Texture2D GetNoiseTexture()
        {
            if (!isModernRendering) noiseTexture = null;
            else noiseTexture = TerrainMaterial.GetTexture("_Noise") as Texture2D;
            return noiseTexture;
        }

        private static int GetTerrainLayersCount()
        {
            if (WorldTerrain != null && WorldTerrain.terrainData != null && WorldTerrain.terrainData.terrainLayers != null)
                terrainLayersCount = WorldTerrain.terrainData.terrainLayers.Length;
            else
                terrainLayersCount = 0;

            return terrainLayersCount;
        }

        public static void SwitchTerrainLayer(Terrain terrain, int replaceIndex, TerrainLayer terrainLayer)
        {
            if (terrain != null && terrain.terrainData != null && terrain.terrainData.terrainLayers != null)
            {
                TerrainLayer[] layers = terrain.terrainData.terrainLayers;
                if (replaceIndex < layers.Length)
                {
                    layers[replaceIndex] = terrainLayer;
                    terrain.terrainData.terrainLayers = layers;
                    terrain.Flush();
                }
            }
        }

        public static void SetMainTerrainMaterialDefault(Terrain terrain)
        {
            TDebug.TraceMessage();

            if (terrain == null)
                throw new Exception("No Terrain Component Found! (SetMainTerrainMaterialDefault)");

#if !UNITY_2019_1_OR_NEWER
            terrain.materialType = Terrain.MaterialType.Custom;
#endif
            Material mat = terrain.materialTemplate;

            //if (mat != null) return;

            string materialPath = TTerraWorld.WorkDirectoryLocalPath + "Terrain.mat";

            if (!File.Exists(materialPath))
            {
                TResourcesManager.LoadAllResources();
                AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(TResourcesManager.TerraFormerMaterial), materialPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }

            mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
            mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
            mat.SetTexture("_SnowDiffuse", TResourcesManager.snowAlbedo);
            mat.SetTexture("_SnowNormalmap", TResourcesManager.snowNormalmap);
            mat.SetTexture("_SnowMaskmap", TResourcesManager.snowMaskmap);
            mat.SetTexture("_Noise", TResourcesManager.noise);

            //Texture2D colormap = AssetDatabase.LoadAssetAtPath(TTerraWorld.WorkDirectoryLocalPath + "ColorMap.jpg", typeof(Texture2D)) as Texture2D;
            //
            //if (colormap != null)
            //    mat.SetTexture("_ColorMap", colormap);

            TTerraWorldTerrainManager.SetTerrainMaterial(terrain, mat);
        }

        public static void SetTerrainMaterialDefaultBG(Terrain terrain)
        {
            TDebug.TraceMessage();

            if (terrain == null)
                throw new Exception("No Terrain Component Found! (SetMainTerrainMaterialDefault)");

#if !UNITY_2019_1_OR_NEWER
            terrain.materialType = Terrain.MaterialType.Custom;
#endif
            Material mat = terrain.materialTemplate;

            //if (mat != null) return;

            string materialPath = TTerraWorld.WorkDirectoryLocalPath + "BGTerrain.mat";

            if (!File.Exists(materialPath))
            {
                TResourcesManager.LoadAllResources();
                AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(TResourcesManager.TerraFormerMaterialBG), materialPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
            }

            mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
            mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
            mat.SetTexture("_SnowDiffuse", TResourcesManager.snowAlbedo);
            mat.SetTexture("_SnowNormalmap", TResourcesManager.snowNormalmap);
            mat.SetTexture("_SnowMaskmap", TResourcesManager.snowMaskmap);
            mat.SetTexture("_Noise", TResourcesManager.noise);

            TTerraWorldTerrainManager.SetTerrainMaterialBG(terrain, mat);
        }

        //  public static void SetTerrainMaterialStandard()
        //  {
        //      TDebug.TraceMessage();
        //      Material mat;
        //      string materialPath = TTerraWorld.WorkDirectoryPath + "Terrain.mat";
        //
        //      if (File.Exists(materialPath))
        //      {
        //          mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //          mat.shader = Shader.Find("Nature/Terrain/Standard");
        //      }
        //      else
        //      {
        //          mat = SetTerrainMaterialTerraFormer();
        //          mat.shader = Shader.Find("Nature/Terrain/Standard");
        //      }
        //  }

        //   public static void SetTerrainMaterialStandardBG()
        //   {
        //       TDebug.TraceMessage();
        //       Material mat;
        //       string materialPath = TTerraWorld.WorkDirectoryPath + "BGTerrain.mat";
        //
        //       if (File.Exists(materialPath))
        //       {
        //           mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //           mat.shader = Shader.Find("Nature/Terrain/Standard");
        //       }
        //       else
        //       {
        //           mat = SetTerrainMaterialTerraFormerBG();
        //           mat.shader = Shader.Find("Nature/Terrain/Standard");
        //       }
        //   }

        //  public static Material SetTerrainMaterialTerraFormer()
        //  {
        //      TDebug.TraceMessage();
        //      Material mat;
        //      string materialPath = TTerraWorld.WorkDirectoryPath + "Terrain.mat";
        //
        //      if (File.Exists(materialPath))
        //      {
        //          mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //          mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
        //          return mat;
        //      }
        //      else
        //      {
        //          TResourcesManager.LoadAllResources();
        //          AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(TResourcesManager.TerraFormerMaterial), materialPath);
        //          AssetDatabase.SaveAssets();
        //          AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        //          mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //          TTerraWorldManager.TerrainParamsScript.SetTerrainMaterial(mat);
        //          mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
        //          mat.SetTexture("_SnowDiffuse", TResourcesManager.snowAlbedo);
        //          mat.SetTexture("_SnowNormalmap", TResourcesManager.snowNormalmap);
        //          mat.SetTexture("_SnowMaskmap", TResourcesManager.snowMaskmap);
        //          mat.SetTexture("_Noise", TResourcesManager.noise);
        //
        //          Texture2D colormap = AssetDatabase.LoadAssetAtPath(TTerraWorld.WorkDirectoryPath + "ColorMap.jpg", typeof(Texture2D)) as Texture2D;
        //
        //          if (colormap != null)
        //              mat.SetTexture("_ColorMap", colormap);
        //
        //          return TerrainMaterial;
        //      }
        //  }
        //
        //  public static Material SetTerrainMaterialTerraFormerBG()
        //  {
        //      TDebug.TraceMessage();
        //      Material mat;
        //      string materialPath = TTerraWorld.WorkDirectoryPath + "BGTerrain.mat";
        //
        //      if (File.Exists(materialPath))
        //      {
        //          mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //          mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
        //          return mat;
        //      }
        //      else
        //      {
        //          TResourcesManager.LoadAllResources();
        //          AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(TResourcesManager.TerraFormerMaterialBG), materialPath);
        //          AssetDatabase.SaveAssets();
        //          AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        //          mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;
        //          TTerraWorldManager.TerrainParamsScript.SetTerrainMaterialBG(mat);
        //          mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
        //          mat.SetTexture("_SnowDiffuse", TResourcesManager.snowAlbedo);
        //          mat.SetTexture("_SnowNormalmap", TResourcesManager.snowNormalmap);
        //          mat.SetTexture("_SnowMaskmap", TResourcesManager.snowMaskmap);
        //          mat.SetTexture("_Noise", TResourcesManager.noise);
        //
        //          return TerrainMaterial;
        //      }
        //  }

#if TERRAWORLD_PRO
        public static Material SetTerrainMaterial
        (
            Terrain terrain,
            string materialPath,
            bool modernRendering,
            bool hasTessellation,
            bool hasHeightBlending,
            bool hasColormapBlending,
            bool hasProceduralSnow,
            bool hasProceduralPuddles,
            bool hasFlatShading,
            Texture2D waterMask = null
        )
        {
            TDebug.TraceMessage();
            Material mat = null;
            if (terrain == null || terrain.terrainData == null || string.IsNullOrEmpty(materialPath)) return mat;

            if (File.Exists(materialPath))
            {
                mat = AssetDatabase.LoadAssetAtPath(materialPath, typeof(Material)) as Material;

                if (modernRendering)
                {
                    if (!hasTessellation)
                        mat.shader = Shader.Find("TerraUnity/TerraFormer Instanced");
                    else
                        mat.shader = Shader.Find("TerraUnity/TerraFormer");
                }
                else
                    mat.shader = Shader.Find("Nature/Terrain/Standard");
            }
            else
            {
                if (modernRendering)
                {
                    if (!hasTessellation)
                        mat = new Material(Shader.Find("TerraUnity/TerraFormer Instanced"));
                    else
                        mat = new Material(Shader.Find("TerraUnity/TerraFormer"));
                }
                else
                    mat = new Material(Shader.Find("Nature/Terrain/Standard"));

                if (File.Exists(materialPath)) AssetDatabase.DeleteAsset(materialPath);
                AssetDatabase.CreateAsset(mat, materialPath);
                AssetDatabase.ImportAsset(materialPath, ImportAssetOptions.ForceUpdate);
                AssetDatabase.Refresh();
            }

            if (modernRendering)
            {
                if (hasTessellation) mat.EnableKeyword("_TESSELLATION"); else mat.DisableKeyword("_TESSELLATION");
                if (hasHeightBlending) mat.EnableKeyword("_HEIGHTMAPBLENDING"); else mat.DisableKeyword("_HEIGHTMAPBLENDING");
                if (hasColormapBlending) mat.EnableKeyword("_COLORMAPBLENDING"); else mat.DisableKeyword("_COLORMAPBLENDING");
                if (hasProceduralSnow) mat.EnableKeyword("_PROCEDURALSNOW"); else mat.DisableKeyword("_PROCEDURALSNOW");
                if (hasProceduralPuddles) mat.EnableKeyword("_PROCEDURALPUDDLES"); else mat.DisableKeyword("_PROCEDURALPUDDLES");
                if (hasFlatShading) mat.EnableKeyword("_FLATSHADING"); else mat.DisableKeyword("_FLATSHADING");

                TResourcesManager.LoadAllResources();
                mat.SetTexture("_SnowDiffuse", TResourcesManager.snowAlbedo);
                mat.SetTexture("_SnowNormalmap", TResourcesManager.snowNormalmap);
                mat.SetTexture("_SnowMaskmap", TResourcesManager.snowMaskmap);
                mat.SetTexture("_Noise", TResourcesManager.noise);

                if (waterMask != null) mat.SetTexture("_WaterMask", waterMask);
            }

#if !UNITY_2019_1_OR_NEWER
            terrain.materialType = Terrain.MaterialType.Custom;
#endif

            terrain.materialTemplate = mat;

            if (modernRendering)
                terrain.drawInstanced = hasTessellation;
            else
                terrain.drawInstanced = true;

            return mat;
        }

#endif

        //public static void SyncMaterials()
        //{
        //    //if (renderingNode == null) renderingNode = worldGraph.renderingGraph.GetEntryNode();
        //    //if (renderingNode == null) return;
        //
        //    Initialize();
        //    //UpdateParams();
        //}

        //public static void Initialize()
        //{
        //    renderingNode =  worldGraph.renderingGraph.GetEntryNode();
        //    if (renderingNode == null) return;
        //    
        //    if (renderingNode == null || WorldTerrain == null || WorldTerrain.terrainData == null) return;
        //    string matPath = AssetDatabase.GetAssetPath(WorldTerrain.terrainData);
        //    if (string.IsNullOrEmpty(matPath)) return;
        //    
        //    bool isModernRendering = TTerraWorldManager.TerrainParamsScript.TerrainIsModernRendering;
        //    bool hasTessellation = TTerraWorldManager.TerrainParamsScript.terrainHasTessellation;
        //    bool hasHeightmapBlending = TTerraWorldManager.TerrainParamsScript.terrainHasHeightmapBlending;
        //    bool hasColormapBlending = TTerraWorldManager.TerrainParamsScript.terrainHasColormapBlending;
        //    bool hasProceduralSnow = TTerraWorldManager.TerrainParamsScript.terrainHasProceduralSnow;
        //    bool hasProceduralPuddles = TTerraWorldManager.TerrainParamsScript.terrainHasProceduralPuddles;
        //    bool isFlatShading = TTerraWorldManager.TerrainParamsScript.terrainIsFlatShading;
        //    
        //    SwitchTerrainMaterial
        //    (
        //        WorldTerrain,
        //        Path.GetDirectoryName(matPath) + "/Terrain.mat",
        //        isModernRendering,
        //        //renderingNode.renderingParams.instancedDrawing,
        //        hasTessellation,
        //        hasHeightmapBlending,
        //        hasColormapBlending,
        //        hasProceduralSnow,
        //        hasProceduralPuddles,
        //        isFlatShading
        //    );
        //    
        //    if (TTerraWorldManager.MainTerrainGO.transform.Find("Background Terrain") != null && TTerraWorldManager.MainTerrainGO.transform.Find("Background Terrain").GetComponent<Terrain>() != null)
        //    {
        //        Terrain t = TTerraWorldManager.MainTerrainGO.transform.Find("Background Terrain").GetComponent<Terrain>();
        //    
        //        SwitchTerrainMaterial
        //        (
        //            t,
        //            Path.GetDirectoryName(AssetDatabase.GetAssetPath(t.terrainData)) + "/BGTerrain.mat",
        //            isModernRendering,
        //            //renderingNode.renderingParams.instancedDrawing,
        //            false,
        //            false,
        //            false,
        //            TTerraWorld.WorldGraph.FXGraph.GetEntryNode().fxParams.BGTerrainHasSnow,
        //            false,
        //            isFlatShading
        //        );
        //    }
        //    
        //    if (WorldTerrain != null && WorldTerrain.terrainData != null)
        //        terrainLayersCount = GetTerrainLayersCountFromWorld(WorldTerrain);
        //    else
        //        terrainLayersCount = 0;
        //}

        //private static void SwitchTerrainInstancedDrawing(Terrain tile)
        //{
        //   // if (renderingNode == null) return;
        //
        //    //bool isModernRendering = TerrainRenderingManager.isModernRendering;
        //    //bool hasTessellation = TTerraWorldManager.TerrainParamsScript.terrainHasTessellation;
        //
        //    if (isModernRendering)
        //        tile.drawInstanced = isTessellated;
        //    else
        //        tile.drawInstanced = true;
        //}

        //private static void UpdateParams()
        //{
        //    if (renderingNode == null || !TTerraWorldManager.TerraWorldParamsScript.terrainIsModernRendering || terrainMaterial == null) return;
        //
        //    try
        //    {
        //        GameObject worldReference = TTerraWorldManager.MainTerrainGO;
        //        GameObject BGTerrainObj = worldReference?.transform.Find("Background Terrain")?.gameObject;
        //        BGTerrainMaterial = BGTerrainObj?.GetComponent<Terrain>()?.materialTemplate;
        //    }
        //    catch { }
        //    
        //    // Surface Tint
        //    //-----------------------------------------------------------------------
        //    terrainMaterial.SetColor
        //    (
        //        "_LightingColor",
        //        new Color
        //        (
        //            renderingNode.renderingParams.surfaceTintColorMAIN.X,
        //            renderingNode.renderingParams.surfaceTintColorMAIN.Y,
        //            renderingNode.renderingParams.surfaceTintColorMAIN.Z,
        //            renderingNode.renderingParams.surfaceTintColorMAIN.W
        //        )
        //    );
        //    
        //    if (BGTerrainMaterial != null)
        //    {
        //        BGTerrainMaterial.SetColor
        //        (
        //            "_LightingColor",
        //            new Color
        //            (
        //                renderingNode.renderingParams.surfaceTintColorBG.X,
        //                renderingNode.renderingParams.surfaceTintColorBG.Y,
        //                renderingNode.renderingParams.surfaceTintColorBG.Z,
        //                renderingNode.renderingParams.surfaceTintColorBG.W
        //            )
        //        );
        //    }
        //    
        //    // Tessellation
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.tessellation)
        //        terrainMaterial.EnableKeyword("_TESSELLATION");
        //    else
        //        terrainMaterial.DisableKeyword("_TESSELLATION");
        //    
        //    terrainMaterial.SetFloat("_EdgeLength", renderingNode.renderingParams.tessellationQuality);
        //    terrainMaterial.SetFloat("_Phong", renderingNode.renderingParams.edgeSmoothness);
        //    
        //    // Heightmap Blending
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.heightmapBlending)
        //        terrainMaterial.EnableKeyword("_HEIGHTMAPBLENDING");
        //    else
        //        terrainMaterial.DisableKeyword("_HEIGHTMAPBLENDING");
        //    
        //    terrainMaterial.SetFloat("_HeightmapBlending", renderingNode.renderingParams.heightBlending);
        //    
        //    // Colormap Blending
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.colormapBlending)
        //        terrainMaterial.EnableKeyword("_COLORMAPBLENDING");
        //    else
        //        terrainMaterial.DisableKeyword("_COLORMAPBLENDING");
        //    
        //    colormapTexture = terrainMaterial.GetTexture("_ColorMap") as Texture2D;
        //    
        //    if (colormapTexture == null)
        //        terrainMaterial.DisableKeyword("_COLORMAPBLENDING");
        //    
        //    if (renderingNode.renderingParams.colormapBlending)
        //    {
        //        if (colormapTexture != null)
        //        {
        //            terrainMaterial.SetFloat("_BlendingDistance", renderingNode.renderingParams.colormapBlendingDistance);
        //            terrainMaterial.SetFloat("_Blend", renderingNode.renderingParams.colormapBlendingRange);
        //        }
        //    }
        //    
        //    // Procedural Snow
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.proceduralSnow)
        //    {
        //        // Setting snow for the main terrain
        //        terrainMaterial.EnableKeyword("_PROCEDURALSNOW");
        //        terrainMaterial.SetFloat("_SnowState", 1);
        //    
        //        // Setting snow for the background terrain
        //        if (BGTerrainMaterial != null)
        //        {
        //            if (TTerraWorld.WorldGraph.FXGraph.GetEntryNode().fxParams.BGTerrainHasSnow)
        //            {
        //                BGTerrainMaterial.EnableKeyword("_PROCEDURALSNOW");
        //                BGTerrainMaterial.SetFloat("_SnowState", 1);
        //            }
        //            else
        //                BGTerrainMaterial.DisableKeyword("_PROCEDURALSNOW");
        //        }
        //    }
        //    else
        //    {
        //        // Setting snow for the main terrain
        //        terrainMaterial.DisableKeyword("_PROCEDURALSNOW");
        //        terrainMaterial.SetFloat("_SnowState", 0);
        //    
        //        // Setting snow for the background terrain
        //        if (BGTerrainMaterial != null)
        //        {
        //            BGTerrainMaterial.DisableKeyword("_PROCEDURALSNOW");
        //            BGTerrainMaterial.SetFloat("_SnowState", 0);
        //        }
        //    }
        //    
        //    snowTexture = terrainMaterial.GetTexture("_SnowDiffuse") as Texture2D;
        //    
        //    // Setting snow params for the main terrain
        //    terrainMaterial.SetColor("_SnowColor", new Color(renderingNode.renderingParams.snowColorR, renderingNode.renderingParams.snowColorG, renderingNode.renderingParams.snowColorB));
        //    terrainMaterial.SetFloat("_SnowTile", renderingNode.renderingParams.snowTiling);
        //    terrainMaterial.SetFloat("_SnowAmount", renderingNode.renderingParams.snowAmount);
        //    terrainMaterial.SetFloat("_SnowAngle", renderingNode.renderingParams.snowAngles);
        //    terrainMaterial.SetFloat("_NormalInfluence", renderingNode.renderingParams.snowNormalInfluence);
        //    terrainMaterial.SetFloat("_SnowPower", renderingNode.renderingParams.snowPower);
        //    terrainMaterial.SetFloat("_SnowSmoothness", renderingNode.renderingParams.snowSmoothness);
        //    //terrainMaterial.SetFloat("_SnowMetallic", renderingNode.snowMetallic);
        //    
        //    // Setting snow params for the background terrain
        //    if (BGTerrainMaterial != null)
        //    {
        //        BGTerrainMaterial.SetColor("_SnowColor", new Color(renderingNode.renderingParams.snowColorR, renderingNode.renderingParams.snowColorG, renderingNode.renderingParams.snowColorB));
        //        BGTerrainMaterial.SetFloat("_SnowTile", renderingNode.renderingParams.snowTiling);
        //        BGTerrainMaterial.SetFloat("_SnowAmount", renderingNode.renderingParams.snowAmount);
        //        BGTerrainMaterial.SetFloat("_SnowAngle", renderingNode.renderingParams.snowAngles);
        //        BGTerrainMaterial.SetFloat("_NormalInfluence", renderingNode.renderingParams.snowNormalInfluence);
        //        BGTerrainMaterial.SetFloat("_SnowPower", renderingNode.renderingParams.snowPower);
        //        BGTerrainMaterial.SetFloat("_SnowSmoothness", renderingNode.renderingParams.snowSmoothness);
        //        //BGTerrainMaterial.SetFloat("_SnowMetallic", renderingNode.snowMetallic);
        //    }
        //    
        //    // Procedural Puddles
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.proceduralPuddles)
        //        terrainMaterial.EnableKeyword("_PROCEDURALPUDDLES");
        //    else
        //        terrainMaterial.DisableKeyword("_PROCEDURALPUDDLES");
        //    
        //    noiseTexture = terrainMaterial.GetTexture("_Noise") as Texture2D;
        //    
        //    terrainMaterial.SetColor("_PuddleColor", new Color(renderingNode.renderingParams.puddleColorR, renderingNode.renderingParams.puddleColorG, renderingNode.renderingParams.puddleColorB));
        //    terrainMaterial.SetFloat("_Refraction", renderingNode.renderingParams.puddleRefraction);
        //    terrainMaterial.SetFloat("_PuddleMetallic", renderingNode.renderingParams.puddleMetallic);
        //    terrainMaterial.SetFloat("_PuddleSmoothness", renderingNode.renderingParams.puddleSmoothness);
        //    terrainMaterial.SetFloat("_WaterHeight", renderingNode.renderingParams.puddlewaterHeight);
        //    terrainMaterial.SetFloat("_Slope", renderingNode.renderingParams.puddleSlope);
        //    terrainMaterial.SetFloat("_SlopeMin", renderingNode.renderingParams.puddleMinSlope);
        //    terrainMaterial.SetFloat("_NoiseTiling", renderingNode.renderingParams.puddleNoiseTiling);
        //    terrainMaterial.SetFloat("_NoiseIntensity", renderingNode.renderingParams.puddleNoiseInfluence);
        //    
        //    // Flat Shading
        //    //-----------------------------------------------------------------------
        //    
        //    if (renderingNode.renderingParams.isFlatShading)
        //        terrainMaterial.EnableKeyword("_FLATSHADING");
        //    else
        //        terrainMaterial.DisableKeyword("_FLATSHADING");
        //    
        //    // Terrain Material Per Layer Settings
        //    //-----------------------------------------------------------------------
        //    
        //    for (int i = 0; i < terrainLayersCount; i++)
        //    {
        //        if (i == 0)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement1", renderingNode.renderingParams.displacement1);
        //                terrainMaterial.SetFloat("_HeightShift1", renderingNode.renderingParams.heightOffset1);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover1", renderingNode.renderingParams.tilingRemover1);
        //            terrainMaterial.SetFloat("_NoiseTiling1", renderingNode.renderingParams.noiseTiling1);
        //            terrainMaterial.SetColor("_LayerColor1", new Color(renderingNode.renderingParams.layerColor1R, renderingNode.renderingParams.layerColor1G, renderingNode.renderingParams.layerColor1B));
        //            terrainMaterial.SetFloat("_LayerAO1", renderingNode.renderingParams.layerAO1);
        //        }
        //        else if (i == 1)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement2", renderingNode.renderingParams.displacement2);
        //                terrainMaterial.SetFloat("_HeightShift2", renderingNode.renderingParams.heightOffset2);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover2", renderingNode.renderingParams.tilingRemover2);
        //            terrainMaterial.SetFloat("_NoiseTiling2", renderingNode.renderingParams.noiseTiling2);
        //            terrainMaterial.SetColor("_LayerColor2", new Color(renderingNode.renderingParams.layerColor2R, renderingNode.renderingParams.layerColor2G, renderingNode.renderingParams.layerColor2B));
        //            terrainMaterial.SetFloat("_LayerAO2", renderingNode.renderingParams.layerAO2);
        //        }
        //        else if (i == 2)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement3", renderingNode.renderingParams.displacement3);
        //                terrainMaterial.SetFloat("_HeightShift3", renderingNode.renderingParams.heightOffset3);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover3", renderingNode.renderingParams.tilingRemover3);
        //            terrainMaterial.SetFloat("_NoiseTiling3", renderingNode.renderingParams.noiseTiling3);
        //            terrainMaterial.SetColor("_LayerColor3", new Color(renderingNode.renderingParams.layerColor3R, renderingNode.renderingParams.layerColor3G, renderingNode.renderingParams.layerColor3B));
        //            terrainMaterial.SetFloat("_LayerAO3", renderingNode.renderingParams.layerAO3);
        //        }
        //        else if (i == 3)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement4", renderingNode.renderingParams.displacement4);
        //                terrainMaterial.SetFloat("_HeightShift4", renderingNode.renderingParams.heightOffset4);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover4", renderingNode.renderingParams.tilingRemover4);
        //            terrainMaterial.SetFloat("_NoiseTiling4", renderingNode.renderingParams.noiseTiling4);
        //            terrainMaterial.SetColor("_LayerColor4", new Color(renderingNode.renderingParams.layerColor4R, renderingNode.renderingParams.layerColor4G, renderingNode.renderingParams.layerColor4B));
        //            terrainMaterial.SetFloat("_LayerAO4", renderingNode.renderingParams.layerAO4);
        //        }
        //        else if (i == 4)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement5", renderingNode.renderingParams.displacement5);
        //                terrainMaterial.SetFloat("_HeightShift5", renderingNode.renderingParams.heightOffset5);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover5", renderingNode.renderingParams.tilingRemover5);
        //            terrainMaterial.SetFloat("_NoiseTiling5", renderingNode.renderingParams.noiseTiling5);
        //            terrainMaterial.SetColor("_LayerColor5", new Color(renderingNode.renderingParams.layerColor5R, renderingNode.renderingParams.layerColor5G, renderingNode.renderingParams.layerColor5B));
        //            terrainMaterial.SetFloat("_LayerAO5", renderingNode.renderingParams.layerAO5);
        //        }
        //        else if (i == 5)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement6", renderingNode.renderingParams.displacement6);
        //                terrainMaterial.SetFloat("_HeightShift6", renderingNode.renderingParams.heightOffset6);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover6", renderingNode.renderingParams.tilingRemover6);
        //            terrainMaterial.SetFloat("_NoiseTiling6", renderingNode.renderingParams.noiseTiling6);
        //            terrainMaterial.SetColor("_LayerColor6", new Color(renderingNode.renderingParams.layerColor6R, renderingNode.renderingParams.layerColor6G, renderingNode.renderingParams.layerColor6B));
        //            terrainMaterial.SetFloat("_LayerAO6", renderingNode.renderingParams.layerAO6);
        //        }
        //        else if (i == 6)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement7", renderingNode.renderingParams.displacement7);
        //                terrainMaterial.SetFloat("_HeightShift7", renderingNode.renderingParams.heightOffset7);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover7", renderingNode.renderingParams.tilingRemover7);
        //            terrainMaterial.SetFloat("_NoiseTiling7", renderingNode.renderingParams.noiseTiling7);
        //            terrainMaterial.SetColor("_LayerColor7", new Color(renderingNode.renderingParams.layerColor7R, renderingNode.renderingParams.layerColor7G, renderingNode.renderingParams.layerColor7B));
        //            terrainMaterial.SetFloat("_LayerAO7", renderingNode.renderingParams.layerAO7);
        //        }
        //        else if (i == 7)
        //        {
        //            if (renderingNode.renderingParams.tessellation)
        //            {
        //                terrainMaterial.SetFloat("_Displacement8", renderingNode.renderingParams.displacement8);
        //                terrainMaterial.SetFloat("_HeightShift8", renderingNode.renderingParams.heightOffset8);
        //            }
        //    
        //            terrainMaterial.SetFloat("_TilingRemover8", renderingNode.renderingParams.tilingRemover8);
        //            terrainMaterial.SetFloat("_NoiseTiling8", renderingNode.renderingParams.noiseTiling8);
        //            terrainMaterial.SetColor("_LayerColor8", new Color(renderingNode.renderingParams.layerColor8R, renderingNode.renderingParams.layerColor8G, renderingNode.renderingParams.layerColor8B));
        //            terrainMaterial.SetFloat("_LayerAO8", renderingNode.renderingParams.layerAO8);
        //        }
        //    }
        //}

        //public static void UpdateTerrainLayers()
        //{
        //    //WorldTerrain = TTerraWorldManager.MainTerrainGO.GetComponent<Terrain>();
        //
        //    if (WorldTerrain == null) return;
        //
        //    TColormapGraph colormapGraph = worldGraph.colormapGraph;
        //    List<TerrainLayer> layersList = new List<TerrainLayer>();
        //    TNode masterNode = null;
        //    int maximumLayers = 4;
        //    int detectedCount = 0;
        //
        //    for (int i = 0; i < colormapGraph.nodes.Count; i++)
        //    {
        //        if (detectedCount < maximumLayers)
        //        {
        //            TNode node = colormapGraph.nodes[i];
        //
        //            if (node.GetType() == typeof(TerrainLayerMaster1))
        //                masterNode = (TerrainLayerMaster1)node;
        //            else if (node.GetType() == typeof(TerrainLayerMaster2))
        //                masterNode = (TerrainLayerMaster2)node;
        //            else if (node.GetType() == typeof(TerrainLayerMaster3))
        //                masterNode = (TerrainLayerMaster3)node;
        //            else if (node.GetType() == typeof(TerrainLayerMaster4))
        //                masterNode = (TerrainLayerMaster4)node;
        //
        //            if (masterNode != null && masterNode.inputConnections[0] != null)
        //            {
        //                Mask2DetailTexture layerNode = (Mask2DetailTexture)worldGraph.GetNodeByID(masterNode.inputConnections[0].previousNodeID);
        //
        //                if (layerNode != null && !string.IsNullOrEmpty(layerNode.terrainLayerPath) && File.Exists(layerNode.terrainLayerPath))
        //                {
        //                    TerrainLayer layer = AssetDatabase.LoadAssetAtPath(layerNode.terrainLayerPath, typeof(TerrainLayer)) as TerrainLayer;
        //                    layersList.Add(layer);
        //                    detectedCount++;
        //                }
        //            }
        //        }
        //    }
        //
        //    if (layersList.Count > 0)
        //    {
        //        if (WorldTerrain != null && WorldTerrain.terrainData != null)
        //        {
        //            WorldTerrain.terrainData.terrainLayers = layersList.ToArray();
        //            WorldTerrain.Flush();
        //        }
        //    }
        //}
    }
}
#endif
#endif

