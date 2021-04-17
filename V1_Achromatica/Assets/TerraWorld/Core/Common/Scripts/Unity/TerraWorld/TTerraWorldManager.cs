using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Reflection;

#if TERRAWORLD_PRO
using UnityEngine.Rendering.PostProcessing;
using TerraUnity.Edittime;
#endif

#if TERRAWORLD_XPRO
using TerraUnity.Graph;
#endif

namespace TerraUnity.Runtime
{
    [ExecuteInEditMode]
    public class TTerraWorldManager : MonoBehaviour
    {
        //#if TERRAWORLD_XPRO
        //    public TXGraph xGraph;
        //#endif
        

#pragma warning disable CS0414 // Add readonly modifier
        //[HideInInspector]
        public string _workDirectoryLocalPath1 = "";
        public static bool isQuitting = false;
#pragma warning restore CS0414 // Add readonly modifier

        public static bool worldIsInitialized = false;

        public static TTerraWorldManager TerraWorldManagerScript { get => GetTerraWorldManager(); }
        private static TTerraWorldManager _terraWorldManagerScript;


        public static GameObject SceneSettingsGO1 { get => GetSceneSettingsGameObject(); }
        private static GameObject _sceneSettingsGO;

        public static TTerraWorldTerrainManager TerrainParamsScript { get => GetTerrainParams(); }
        private static TTerraWorldTerrainManager _terrainParamsScript;

        public static GameObject MainTerraworldGameObject { get => GetMainTerraworldGameObject(); }
        private static GameObject _mainTerraworldGameObject;

        public static GameObject MainTerrainGO { get => GetMainTerrainGameObject(); }
        private static GameObject _mainTerrainGO;

        public static Terrain MainTerrain { get => GetMainTerrain(); }
        private static Terrain _mainTerrain;

        public static GameObject BackgroundTerrainGO { get => GetBackgroundTerrainGameObject(); }
        private static GameObject _backgroundTerrainGO;

        public static Terrain BackgroundTerrain { get => GetBackgroundTerrain(); }
        private static Terrain _backgroundTerrain;

        public static GlobalTimeManager GlobalTimeManagerScript { get => GetGlobalTimeManagerScript(); }
        private static GlobalTimeManager _globalTimeManagerScript;
        [HideInInspector, Range(1, 3)] public int timeOfDayMode = 1; // 0 = off (Disabled for user controls), 1 = Manual (Controlled from TerraWorld), 2 = Auto (Day/Night Cycle)

        public static CloudsManager CloudsManagerScript { get => GetCloudsManagerScript(); }
        private static CloudsManager _cloudsManagerScript;

        public static Crepuscular GodRaysManagerScript { get => GetGodRaysManagerScript(); }
        private static Crepuscular _godRaysManagerScript;

        public static TimeOfDay TimeOfDayManagerScript { get => GetTimeOfDayManagerScript(); }
        private static TimeOfDay _timeOfDayManagerScript;

        public static HorizonFog HorizonFogManagerScript { get => GetHorizonFogManagerScript(); }
        private static HorizonFog _horizonFogManagerScript;

        public static WaterManager WaterManagerScript { get => GetWaterManagerScript(); }
        private static WaterManager _waterManagerScript;

        public static SnowManager SnowManagerScript { get => GetSnowManagerScript(); }
        private static SnowManager _snowManagerScript;

        public static WindManager WindManagerScript { get => GetWindManagerScript(); }
        private static WindManager _windManagerScript;

        public static FlatShadingManager FlatShadingManagerScript { get => GetFlatShadingManagerScript(); }
        private static FlatShadingManager _flatShadingManagerScript;

        public static AtmosphericScattering AtmosphericScatteringManagerScript { get => GetAtmosphericScatteringManagerScript(); }
        private static AtmosphericScattering _atmosphericScatteringManagerScript;

        public static AtmosphericScatteringSun AtmosphericScatteringSunScript { get => GetAtmosphericScatteringSunScript(); }
        private static AtmosphericScatteringSun _atmosphericScatteringSunScript;

        public static AtmosphericScatteringDeferred AtmosphericScatteringDeferredScript { get => GetAtmosphericScatteringDeferredScript(); }
        private static AtmosphericScatteringDeferred _atmosphericScatteringDeferredScript;

        public static VolumetricFog VolumetricFogManagerScript { get => GetVolumetricFogManagerScript(); }
        private static VolumetricFog _volumetricFogManagerScript;

        public static LightManagerFogLights LightFogManagerScript { get => GetLightFogManagerScript(); }
        private static LightManagerFogLights _lightFogManagerScript;
        public static float _fogLightIntensity;
        public static float _fogLightRange;

        public static string WorkDirectoryLocalPath { get => getWorkDirectoryLocalPath(); }
        private static string defaultMainTerraworldGameObjectName = "TerraWorld";

        public static string cloudsMaterialName = "Clouds Material.mat";
        public static string cloudsPrefabName = "Clouds Prefab.prefab";
        public static string godRaysMaterialName = "GodRays Material.mat";
        public static string skyMaterialName = "Sky Material.mat";
        public static string starsPrefabName = "Stars Prefab.prefab";
        public static string horizonMaterialName = "Horizon Material.mat";
        public static string postProcessingProfileName = "PostProcessing Profile.asset";
        //public static string waterMaterialName = "Water Material.mat";

        private static string getWorkDirectoryLocalPath()
        {
            string path = TerraWorldManagerScript.GetWorkingDirectoryLocalName();
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            return path;
        }

        private static GameObject GetMainTerraworldGameObject()
        {
            if (_mainTerraworldGameObject == null)
            {
                _mainTerraworldGameObject = GameObject.Find(defaultMainTerraworldGameObjectName);
  
                foreach (GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                        if (go.GetComponent<TTerraWorldManager>() != null)
                        {
                            _mainTerraworldGameObject = go;
                            break;
                        }
                }

                foreach (GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                        if (go.GetComponent<TTerraWorldManager>() != null)
                        {
                            _mainTerraworldGameObject = go;
                            break;
                        }
                }

#if UNITY_EDITOR
                foreach (GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
                {
                    if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                        if (go.GetComponent<WorldTools>() != null)
                        {
                            _mainTerraworldGameObject = go;
                            break;
                        }
                }

                if (_mainTerraworldGameObject == null)
                {
                    _mainTerraworldGameObject = new GameObject(defaultMainTerraworldGameObjectName);
                    _terraWorldManagerScript =_mainTerraworldGameObject.AddComponent<TTerraWorldManager>();
                    _mainTerraworldGameObject.AddComponent<WorldTools>();
                }
#endif
            }

            return _mainTerraworldGameObject;
        }

        private static TTerraWorldManager GetTerraWorldManager()
        {
            if (_terraWorldManagerScript == null)
            {
                _terraWorldManagerScript = MainTerraworldGameObject.GetComponent<TTerraWorldManager>();

                if (_terraWorldManagerScript == null)
                    _terraWorldManagerScript = MainTerraworldGameObject.AddComponent<TTerraWorldManager>();
            }

            return _terraWorldManagerScript;
        }

        private static GameObject GetMainTerrainGameObject()
        {
            if (_mainTerrainGO == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    Terrain terrain = t.GetComponent<Terrain>();

                    if (terrain != null && terrain.GetComponent<TTerraWorldTerrainManager>() != null)
                    {
                        _mainTerrainGO = t.gameObject;
                        break;
                    }
                }
            }

            return _mainTerrainGO;
        }

        private static Terrain GetMainTerrain()
        {
            if (_mainTerrain == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    Terrain terrain = t.GetComponent<Terrain>();

                    if (terrain != null && terrain.GetComponent<TTerraWorldTerrainManager>() != null)
                    {
                        _mainTerrain = terrain;
                        break;
                    }
                }
            }

            return _mainTerrain;
        }

        private static GameObject GetBackgroundTerrainGameObject()
        {
            if (_backgroundTerrainGO == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    Terrain terrain = t.GetComponent<Terrain>();

                    if (terrain != null && terrain.gameObject.name == "Background Terrain")
                    {
                        _backgroundTerrainGO = t.gameObject;
                        break;
                    }
                }
            }

            return _backgroundTerrainGO;
        }

        private static Terrain GetBackgroundTerrain()
        {
            if (_backgroundTerrain == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    Terrain terrain = t.GetComponent<Terrain>();

                    if (terrain != null && terrain.gameObject.name == "Background Terrain")
                    {
                        _backgroundTerrain = terrain;
                        break;
                    }
                }
            }

            return _backgroundTerrain;
        }

        private static TTerraWorldTerrainManager GetTerrainParams()
        {
            if (MainTerrainGO == null) return null;

            if (_terrainParamsScript == null)
            {
                _terrainParamsScript = MainTerrainGO.GetComponent<TTerraWorldTerrainManager>();

                if (_terrainParamsScript == null)
                    _terrainParamsScript = MainTerrainGO.AddComponent<TTerraWorldTerrainManager>();
            }

            return _terrainParamsScript;
        }

        private static GlobalTimeManager GetGlobalTimeManagerScript()
        {
            if (_globalTimeManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    GlobalTimeManager script = t.GetComponent<GlobalTimeManager>();

                    if (script != null)
                    {
                        _globalTimeManagerScript = script;
                        break;
                    }
                }

                if (_globalTimeManagerScript == null)
                    if (SceneSettingsGO1 != null)
                    {
                        _globalTimeManagerScript = SceneSettingsGO1.AddComponent<GlobalTimeManager>();
                        _globalTimeManagerScript.SetDefaults();
                    }
            }

            return _globalTimeManagerScript;
        }

        private static CloudsManager GetCloudsManagerScript()
        {
            if (_mainTerraworldGameObject == null) return null;

            if (_cloudsManagerScript == null)
            {
                foreach (Transform t in _mainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    CloudsManager script = t.GetComponent<CloudsManager>();

                    if (script != null)
                    {
                        _cloudsManagerScript = script;
                        break;
                    }
                }

                if (_cloudsManagerScript == null)
                    if (SceneSettingsGO1 != null)
                        _cloudsManagerScript = SceneSettingsGO1.AddComponent<CloudsManager>();
            }
            else
            {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
                //if (!worldIsInitialized)
                {
                    if (_cloudsManagerScript.cloudsMaterial == null)
                    {
                        Material mat = AssetDatabase.LoadAssetAtPath(WorkDirectoryLocalPath + cloudsMaterialName, typeof(Material)) as Material;

                        if (mat != null)
                            _cloudsManagerScript.cloudsMaterial = mat;
                        else
                        {
                            TResourcesManager.LoadCloudsResources();
                            _cloudsManagerScript.cloudsMaterial = TResourcesManager.cloudsMaterial;
                        }
                    }

                    if (_cloudsManagerScript.cloudPrefab == null)
                    {
                        GameObject go = AssetDatabase.LoadAssetAtPath(WorkDirectoryLocalPath + cloudsPrefabName, typeof(GameObject)) as GameObject;

                        if (go != null)
                            _cloudsManagerScript.cloudPrefab = go;
                        else
                        {
                            TResourcesManager.LoadCloudsResources();
                            _cloudsManagerScript.cloudPrefab = TResourcesManager.cloudPrefab;
                        }
                    }
                }

                if (_cloudsManagerScript.cloudMesh == null)
                {
                    TResourcesManager.LoadCloudsResources();
                    _cloudsManagerScript.cloudMesh = TResourcesManager.cloudMesh;
                }
#endif
#endif
            }

            return _cloudsManagerScript;
        }

        private static Crepuscular GetGodRaysManagerScript()
        {
            if (_godRaysManagerScript == null)
            {
                if (Camera.main != null)
                {
                    Crepuscular script = Camera.main.gameObject.GetComponent<Crepuscular>();

                    if (script != null)
                        _godRaysManagerScript = script;
                    else
                        _godRaysManagerScript = Camera.main.gameObject.AddComponent<Crepuscular>();
                }

                if (_godRaysManagerScript == null)
                {
                    //if (TimeOfDayManagerScript == null || TimeOfDayManagerScript.player == null)
                        //GetTimeOfDayManagerScript();

                    if (TimeOfDayManagerScript.player != null)
                    {
                        Crepuscular script = TimeOfDayManagerScript.player.GetComponent<Crepuscular>();

                        if (script != null)
                            _godRaysManagerScript = script;
                        else
                            _godRaysManagerScript = TimeOfDayManagerScript.player.AddComponent<Crepuscular>();
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
                //if (!worldIsInitialized)
                {
                    if (_godRaysManagerScript.material == null)
                    {
                        Material mat = AssetDatabase.LoadAssetAtPath(WorkDirectoryLocalPath + godRaysMaterialName, typeof(Material)) as Material;

                        if (mat != null)
                            _godRaysManagerScript.material = mat;
                        else
                        {
                            TResourcesManager.LoadGodRaysResources();
                            _godRaysManagerScript.material = TResourcesManager.godRaysMaterial;
                        }
                    }
                }
#endif
#endif
                if (_godRaysManagerScript.sun == null)
                {
                    //if (TimeOfDayManagerScript == null) GetTimeOfDayManagerScript();
                    _godRaysManagerScript.sun = TimeOfDayManagerScript.sun;
                }
            }

            return _godRaysManagerScript;
        }

        private static TimeOfDay GetTimeOfDayManagerScript()
        {
            if (SceneSettingsGO1 == null) return null;

            if (_timeOfDayManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    TimeOfDay script = t.GetComponent<TimeOfDay>();

                    if (script != null)
                    {
                        _timeOfDayManagerScript = script;
                        break;
                    }
                }

                if (_timeOfDayManagerScript == null)
                    if (SceneSettingsGO1 != null)
                        _timeOfDayManagerScript = SceneSettingsGO1.AddComponent<TimeOfDay>();

                if (_timeOfDayManagerScript != null)
                    SetTimeOfDayParams();
            }
            else
                SetTimeOfDayParams();

            return _timeOfDayManagerScript;
        }

        public static void SetTimeOfDayParams()
        {
            if (SceneSettingsGO1 == null) return;

            if (!isQuitting && SceneSettingsGO1 != null)
            {
                if (_timeOfDayManagerScript == null) GetTimeOfDayManagerScript();

                if (_timeOfDayManagerScript.sun == null)
                {
                    foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                        if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                            if (go.GetComponent<Light>() != null && go.GetComponent<Light>().type == LightType.Directional)
                            {
                                _timeOfDayManagerScript.sun = go;
                                break;
                            }
                }

                if (_timeOfDayManagerScript.sun == null) return;

                if (_timeOfDayManagerScript.sunLight == null)
                    _timeOfDayManagerScript.sunLight = _timeOfDayManagerScript.sun.GetComponent<Light>();

                if (_timeOfDayManagerScript.player == null) _timeOfDayManagerScript.player = Camera.main?.gameObject;
                if (_timeOfDayManagerScript.player == null)
                {
                    foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                        if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                            if (go.GetComponent<Camera>() != null)
                            {
                                _timeOfDayManagerScript.player = go;
                                break;
                            }
                }

                //if (!worldIsInitialized)
                {
                    if (_timeOfDayManagerScript.stars == null)
                    {
                        foreach (Transform t in SceneSettingsGO1.GetComponentsInChildren<Transform>(true))
                            if (t != null && t.name == "Night Stars")
                            {
                                _timeOfDayManagerScript.stars = t.gameObject;
                                break;
                            }

#if UNITY_EDITOR
                        if (_timeOfDayManagerScript.stars == null)
                        {
                            string starsPrefabPath = "";

                            if (File.Exists(WorkDirectoryLocalPath + starsPrefabName))
                                starsPrefabPath = WorkDirectoryLocalPath + starsPrefabName;
                            else
                            {
                                TResourcesManager.LoadTimeOfDayResources();
                                starsPrefabPath = AssetDatabase.GetAssetPath(TResourcesManager.starsPrefab);
                            }

                            GameObject starsPrefabGO = AssetDatabase.LoadAssetAtPath(starsPrefabPath, typeof(GameObject)) as GameObject;

                            foreach (Transform t in SceneSettingsGO1.GetComponentsInChildren<Transform>(true))
                                if (t != null && t.name == "Night Stars")
                                    MonoBehaviour.DestroyImmediate(t.gameObject);
                            if (starsPrefabGO != null)
                            {
                                _timeOfDayManagerScript.stars = MonoBehaviour.Instantiate(starsPrefabGO);
                                _timeOfDayManagerScript.stars.name = "Night Stars";
                                _timeOfDayManagerScript.stars.transform.parent = _timeOfDayManagerScript.transform;
                                _timeOfDayManagerScript.stars.transform.localPosition = Vector3.zero;

                                _timeOfDayManagerScript.UpdateAtmosphere(true);
                            }

                        }
#endif
                    }

                    if (_timeOfDayManagerScript.stars != null && _timeOfDayManagerScript.starsRenderer == null)
                    {
                        _timeOfDayManagerScript.starsRenderer = _timeOfDayManagerScript.stars.GetComponent<ParticleSystemRenderer>();

#if UNITY_EDITOR
                        if (_timeOfDayManagerScript.starsRenderer != null)
                        {
                            PreviewAllParticlesInEditorScene();
                            //ParticleSystem particleSystem = timeOfDay.stars.GetComponent<ParticleSystem>();
                            //particleSystem?.Simulate(2);
                            //particleSystem?.Play();
                        }
                        else
                            throw new Exception("Stars Renderer Error!");
#endif

                        _timeOfDayManagerScript.UpdateAtmosphere(true);
                    }


                    if (_timeOfDayManagerScript.skyMaterial != null)
                        RenderSettings.skybox = _timeOfDayManagerScript.skyMaterial;
                    else
                    {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
                        string skyMaterialPath = "";

                        if (File.Exists(WorkDirectoryLocalPath + skyMaterialName))
                            skyMaterialPath = WorkDirectoryLocalPath + skyMaterialName;
                        else
                        {
                            TResourcesManager.LoadTimeOfDayResources();
                            skyMaterialPath = AssetDatabase.GetAssetPath(TResourcesManager.starsPrefab);
                        }

                        _timeOfDayManagerScript.skyMaterial = AssetDatabase.LoadAssetAtPath(skyMaterialPath, typeof(Material)) as Material;
                        RenderSettings.skybox = _timeOfDayManagerScript.skyMaterial;

                        _timeOfDayManagerScript.UpdateAtmosphere(true);
#endif
#endif
                    }
                }
            }
        }

#if UNITY_EDITOR
        private static void PreviewAllParticlesInEditorScene()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(Editor));
            if (assembly == null) return;

            Type particleSystemEditorUtilsType = assembly.GetType("UnityEditor.ParticleSystemEditorUtils");
            if (particleSystemEditorUtilsType == null) return;

            PropertyInfo previewLayers = particleSystemEditorUtilsType.GetProperty("previewLayers", BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            if (previewLayers == null) return;

            uint allLayers = Convert.ToUInt32(uint.MaxValue);
            previewLayers.SetValue(null, allLayers);
        }
#endif

        private static HorizonFog GetHorizonFogManagerScript()
        {
            if (_horizonFogManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    HorizonFog script = t.GetComponent<HorizonFog>();

                    if (script != null)
                    {
                        _horizonFogManagerScript = script;
                        break;
                    }
                }

                if (_horizonFogManagerScript == null)
                {
                    if (SceneSettingsGO1 != null)
                    {
                        GameObject horizonFogGameObject = new GameObject("Horizon Fog");
                        horizonFogGameObject.transform.parent = SceneSettingsGO1.transform;
                        horizonFogGameObject.transform.position = new Vector3(0, -90000f, 0);
                        horizonFogGameObject.transform.eulerAngles = new Vector3(180, 0, 0);
                        horizonFogGameObject.AddComponent<MeshFilter>();
                        horizonFogGameObject.AddComponent<MeshRenderer>();
                        horizonFogGameObject.AddComponent<CameraXZ>();
                        _horizonFogManagerScript = horizonFogGameObject.AddComponent<HorizonFog>();
                        _horizonFogManagerScript.texture = null;
                        _horizonFogManagerScript.textureScale = 1;
                        _horizonFogManagerScript.textureMovement = Vector3.zero;
                        _horizonFogManagerScript.coneHeight = 100000;
                        _horizonFogManagerScript.coneAngle = 60;
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
                //if (!worldIsInitialized)
                {
                    if (_horizonFogManagerScript.volumetricMaterial == null)
                    {
                        Material mat = AssetDatabase.LoadAssetAtPath(WorkDirectoryLocalPath + horizonMaterialName, typeof(Material)) as Material;

                        if (mat != null)
                            _horizonFogManagerScript.volumetricMaterial = mat;
                        else
                        {
                            TResourcesManager.LoadHorizonFogResources();
                            _horizonFogManagerScript.volumetricMaterial = TResourcesManager.volumetricHorizonMaterial;
                        }
                    }
                }
#endif
#endif
            }

            return _horizonFogManagerScript;
        }

        private static WaterManager GetWaterManagerScript()
        {
            if (_waterManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    WaterManager script = t.GetComponent<WaterManager>();

                    if (script != null)
                    {
                        _waterManagerScript = script;
                        break;
                    }
                }

                if (_waterManagerScript == null)
                    if (SceneSettingsGO1 != null)
                        _waterManagerScript = SceneSettingsGO1.AddComponent<WaterManager>();
            }

            return _waterManagerScript;
        }

        private static SnowManager GetSnowManagerScript()
        {
            if (_snowManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    SnowManager script = t.GetComponent<SnowManager>();

                    if (script != null)
                    {
                        _snowManagerScript = script;
                        break;
                    }
                }

                if (_snowManagerScript == null)
                {
                    if (SceneSettingsGO1 != null)
                    {
                        _snowManagerScript = SceneSettingsGO1.AddComponent<SnowManager>();
                        _snowManagerScript.Init();
                    }
                }
            }

            return _snowManagerScript;
        }

        private static WindManager GetWindManagerScript()
        {
            if (_windManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    WindManager script = t.GetComponent<WindManager>();

                    if (script != null)
                    {
                        _windManagerScript = script;
                        break;
                    }
                }

                if (_windManagerScript == null)
                {
                    if (SceneSettingsGO1 != null)
                    {
                        _windManagerScript = SceneSettingsGO1.AddComponent<WindManager>();
                        _windManagerScript.Init();
                    }
                }
            }

            return _windManagerScript;
        }

        private static FlatShadingManager GetFlatShadingManagerScript()
        {
            if (_flatShadingManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    FlatShadingManager script = t.GetComponent<FlatShadingManager>();

                    if (script != null)
                    {
                        _flatShadingManagerScript = script;
                        break;
                    }
                }

                if (_flatShadingManagerScript == null)
                {
                    if (SceneSettingsGO1 != null)
                    {
                        _flatShadingManagerScript = SceneSettingsGO1.AddComponent<FlatShadingManager>();
#if TERRAWORLD_PRO
#if UNITY_EDITOR
                        _flatShadingManagerScript.Init();
#endif
#endif
                    }
                }
            }

            return _flatShadingManagerScript;
        }

#if UNITY_STANDALONE_WIN
        private static AtmosphericScattering GetAtmosphericScatteringManagerScript()
        {
            if (_atmosphericScatteringManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    AtmosphericScattering script = t.GetComponent<AtmosphericScattering>();

                    if (script != null)
                    {
                        _atmosphericScatteringManagerScript = script;
                        break;
                    }
                }

                if (_atmosphericScatteringManagerScript == null)
                    if (SceneSettingsGO1 != null)
                        _atmosphericScatteringManagerScript = SceneSettingsGO1.AddComponent<AtmosphericScattering>();
            }
            else
            {
                GetAtmosphericScatteringSunScript();
                GetAtmosphericScatteringDeferredScript();
            }

            return _atmosphericScatteringManagerScript;
        }

        private static AtmosphericScatteringSun GetAtmosphericScatteringSunScript()
        {
            if (_atmosphericScatteringSunScript == null)
            {
                if (TimeOfDayManagerScript == null || TimeOfDayManagerScript.sun == null)
                    GetTimeOfDayManagerScript();

                _atmosphericScatteringSunScript = TimeOfDayManagerScript.sun.GetComponent<AtmosphericScatteringSun>();

                if (_atmosphericScatteringSunScript == null)
                    _atmosphericScatteringSunScript = TimeOfDayManagerScript.sun.AddComponent<AtmosphericScatteringSun>();
            }

            return _atmosphericScatteringSunScript;
        }

        private static AtmosphericScatteringDeferred GetAtmosphericScatteringDeferredScript()
        {
            if (_atmosphericScatteringDeferredScript == null)
            {
                if (TimeOfDayManagerScript == null || TimeOfDayManagerScript.player == null)
                    GetTimeOfDayManagerScript();

                _atmosphericScatteringDeferredScript = TimeOfDayManagerScript.player.GetComponent<AtmosphericScatteringDeferred>();

                if (_atmosphericScatteringDeferredScript == null)
                    _atmosphericScatteringDeferredScript = TimeOfDayManagerScript.player.AddComponent<AtmosphericScatteringDeferred>();
            }

            return _atmosphericScatteringDeferredScript;
        }
#endif

#if UNITY_STANDALONE_WIN
        private static VolumetricFog GetVolumetricFogManagerScript()
        {
            if (_volumetricFogManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    VolumetricFog script = t.GetComponent<VolumetricFog>();

                    if (script != null && t.GetComponent<Camera>() != null)
                    {
                        _volumetricFogManagerScript = script;
                        break;
                    }
                }

                if (_volumetricFogManagerScript == null)
                {
                    if (TimeOfDayManagerScript == null || TimeOfDayManagerScript.player == null)
                        GetTimeOfDayManagerScript();

                    _volumetricFogManagerScript = TimeOfDayManagerScript.player.GetComponent<VolumetricFog>();

                    if (_volumetricFogManagerScript == null)
                        _volumetricFogManagerScript = TimeOfDayManagerScript.player.AddComponent<VolumetricFog>();
                }
            }
            else
                GetLightFogManagerScript();

            return _volumetricFogManagerScript;
        }
#endif

#if UNITY_STANDALONE_WIN
        private static LightManagerFogLights GetLightFogManagerScript()
        {
            if (_lightFogManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    LightManagerFogLights script = t.GetComponent<LightManagerFogLights>();

                    if (script != null)
                    {
                        _lightFogManagerScript = script;
                        break;
                    }
                }

                if (_lightFogManagerScript == null)
                    if (SceneSettingsGO1 != null)
                        _lightFogManagerScript = SceneSettingsGO1.AddComponent<LightManagerFogLights>();
            }
            else
            {
                _fogLightIntensity = 1;
                _fogLightRange = 1;


                foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
                {
                    if (go.hideFlags != HideFlags.NotEditable && go.hideFlags != HideFlags.HideAndDontSave && go.scene.IsValid())
                    {
                        if (go.GetComponent<Light>() != null && go.GetComponent<Light>().type != LightType.Directional)
                        {
                            FogLight fogLight = go.GetComponent<FogLight>();

                            if (fogLight != null)
                            {
                                _fogLightIntensity = fogLight.m_IntensityMult;
                                _fogLightRange = fogLight.m_RangeMult;
                                //MonoBehaviour.DestroyImmediate(fogLight);
                            }
                            else
                            {
                                fogLight = go.AddComponent<FogLight>();
                                fogLight.m_IntensityMult = _fogLightIntensity;
                                fogLight.m_RangeMult = _fogLightRange;
                            }
                        }
                    }
                }
            }

            return _lightFogManagerScript;
        }
#endif

        private string GetWorkingDirectoryLocalName()
        {
            if (_workDirectoryLocalPath1 == "") OnEnable();
            return _workDirectoryLocalPath1;
        }

        private void OnEnable()
        {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
            EditorApplication.quitting += Quit;

            if (_workDirectoryLocalPath1 == "")
            {
                Material material = TerrainRenderingManager.TerrainMaterial;

                if (material == null)
                {
                    System.Random rand = new System.Random((int)DateTime.Now.Ticks);
                    int WorldID = rand.Next();
                    _workDirectoryLocalPath1 = TAddresses.GetWorkDirectoryPath(WorldID);
                }
                else
                    _workDirectoryLocalPath1 = Path.GetDirectoryName(AssetDatabase.GetAssetPath(material)) + "/";
            }
#endif
#endif
        }

#if UNITY_EDITOR
        public UnityEngine.Object graphFile;

#if TERRAWORLD_PRO
        static void Quit()
        {
            isQuitting = true;
        }
#endif
#endif

#if UNITY_EDITOR
#if TERRAWORLD_PRO
        public static string TerraWorldGraphPath { get => TerraWorldManagerScript.GraphFilePath; set => TerraWorldManagerScript.GraphFilePath = value; }

        private void CheckGraphFile()
        {
            if (graphFile != null)
            {
                string path = AssetDatabase.GetAssetPath(graphFile);

                if (!TTerraWorldGraph.CheckGraph(path))
                    graphFile = null;
            }
        }

        public string GraphFilePath
        {
            get
            {
                if (graphFile != null)
                {
                    string path = TAddresses.projectPath + AssetDatabase.GetAssetPath(graphFile);
                    return path;
                }
                else
                    return null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    AssetDatabase.Refresh();
                    value = value.Replace(TAddresses.projectPath, "");
                    graphFile = AssetDatabase.LoadAssetAtPath(value, typeof(UnityEngine.Object));
                    CheckGraphFile();
                }
                else
                    graphFile = null;
            }
        }

#endif
#endif

        private static GameObject GetSceneSettingsGameObject()
        {
            if (_mainTerraworldGameObject == null) return null;

            if (_sceneSettingsGO == null)
            {
                foreach (Transform t in _mainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                    if (t.hideFlags != HideFlags.NotEditable && t.hideFlags != HideFlags.HideAndDontSave && t.gameObject.scene.IsValid())
                        if (t.name == "Scene Settings" && t.GetComponent<SceneSettingsGameObjectManager>() != null)
                        {
                            _sceneSettingsGO = t.gameObject;
                            break;
                        }
            }

            return _sceneSettingsGO;
        }

        public static void CreateSceneSettingsGameObject()
        {
#if UNITY_EDITOR
#if TERRAWORLD_PRO
            if (!isQuitting && SceneSettingsGO1 == null)
            _sceneSettingsGO = SceneSettingsManager.InstantiateSceneSettings();
#endif
#endif
        }

#if TERRAWORLD_PRO
        public static PostProcessLayer PostProcessLayerScript { get => GetPostProcessLayerScript(); }
        private static PostProcessLayer _postProcessLayerScript;

        public static PostProcessVolume PostProcessVolumeManagerScript { get => GetPostProcessVolumeManagerScript(); }

        private static PostProcessVolume _postProcessVolumeManagerScript;

        private static PostProcessLayer GetPostProcessLayerScript()
        {
            if (_postProcessLayerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    PostProcessLayer script = t.GetComponent<PostProcessLayer>();

                    if (script != null)
                    {
                        _postProcessLayerScript = script;
                        break;
                    }
                }

                if (_postProcessLayerScript == null)
                {
                    if (TimeOfDayManagerScript == null || TimeOfDayManagerScript.player == null)
                        GetTimeOfDayManagerScript();

                    _postProcessLayerScript = TimeOfDayManagerScript.player.GetComponent<PostProcessLayer>();

                    if (_postProcessLayerScript == null)
                        _postProcessLayerScript = TimeOfDayManagerScript.player.AddComponent<PostProcessLayer>();

                    _postProcessLayerScript.volumeLayer = LayerMask.GetMask("TransparentFX");
                    _postProcessLayerScript.antialiasingMode = PostProcessLayer.Antialiasing.TemporalAntialiasing;
                    _postProcessLayerScript.enabled = true;
                    PostProcessVolumeManagerScript.enabled = true;
                }
            }

            return _postProcessLayerScript;
        }

        private static PostProcessVolume GetPostProcessVolumeManagerScript()
        {
            if (_postProcessVolumeManagerScript == null)
            {
                foreach (Transform t in MainTerraworldGameObject.GetComponentsInChildren(typeof(Transform), true))
                {
                    PostProcessVolume script = t.GetComponent<PostProcessVolume>();

                    if (script != null)
                    {
                        _postProcessVolumeManagerScript = script;
                        break;
                    }
                }

                if (_postProcessVolumeManagerScript == null)
                {
                    if (SceneSettingsGO1 != null)
                    {
                        _postProcessVolumeManagerScript = SceneSettingsGO1.GetComponent<PostProcessVolume>();

                        if (_postProcessVolumeManagerScript == null)
                        {
                            _postProcessVolumeManagerScript = SceneSettingsGO1.AddComponent<PostProcessVolume>();
                            _postProcessVolumeManagerScript.isGlobal = true;
                        }
                    }
                }
            }
            else
            {
#if UNITY_EDITOR
                //if (!worldIsInitialized)
                {
                    if (_postProcessVolumeManagerScript != null)
                    {
                        if (_postProcessVolumeManagerScript.sharedProfile == null)
                        {
                            PostProcessProfile PPP = AssetDatabase.LoadAssetAtPath(WorkDirectoryLocalPath + postProcessingProfileName, typeof(PostProcessProfile)) as PostProcessProfile;

                            if (PPP != null)
                                _postProcessVolumeManagerScript.sharedProfile = PPP;
                                //_postProcessVolumeManagerScript.profile = PPP;
                            else
                            {
                                TResourcesManager.LoadPostProcessingResources();
                                _postProcessVolumeManagerScript.sharedProfile = TResourcesManager.postProcessingAsset;
                                //_postProcessVolumeManagerScript.profile = TResourcesManager.postProcessingAsset;
                            }

                            UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
                        }
                    }
                }
#endif
            }

            return _postProcessVolumeManagerScript;
        }

#endif
    }
}

