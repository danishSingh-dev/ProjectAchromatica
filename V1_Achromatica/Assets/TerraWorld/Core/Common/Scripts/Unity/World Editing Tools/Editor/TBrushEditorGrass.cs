#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace TerraUnity.Runtime
{
    public class TBrushEditorGrass : Editor
    {
        public GrassLayer WT;

        public void MaskEditorGUI ()
        {
            //Repaint();

            if (WT.MGP.maskData != null)
            {
                TBrushFunctions.GL = WT;
                WorldToolsParams.globalMode = false;
                WorldToolsParams.isGrassLayer = true;
                GUIStyle style = new GUIStyle(EditorStyles.toolbarButton); style.fixedWidth = 128; style.fixedHeight = 32;

                if (WorldToolsParams.isEditMode)
                {
                    THelpersUIRuntime.GUI_Button(new GUIContent("EXIT EDIT MODE", "Finish editing placement"), style, TBrushFunctions.EditPlacement, 0, 0, Color.red);
                    THelpersUIRuntime.GUI_HelpBox(WorldToolsParams.editingText, MessageType.None);

                    GUILayout.Space(10);
                    int maximumBrushSize = (int)WT.MGP.terrain.terrainData.size.x / 4;
                    int minimumBrushSize = Mathf.Clamp((int)(WT.MGP.terrain.terrainData.size.x / WT.MGP.maskData.Length), 1, maximumBrushSize);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("brushRadius"), new GUIContent("BRUSH RADIUS", "Brush Radius for painting and editing placement"));
                    WT.brushRadius = Mathf.Clamp(WT.brushRadius, minimumBrushSize, maximumBrushSize);
                    GUILayout.Space(5);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("brushDensity"), new GUIContent("BRUSH DENSITY", "Brush Density for painting and editing placement"));
                    GUILayout.Space(10);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("isolateLayer"), new GUIContent("ISOLATE PREVIEW", "Isolate preview and only show this layer in scene view while painting"));
                    GUILayout.Space(20);
                    WorldToolsParams.sectionToggle1 = THelpersUIRuntime.Foldout("TERRAIN LAYERS (TEXTURES) FILTERING", ref WorldToolsParams.sectionToggle1);

                    if (WorldToolsParams.sectionToggle1)
                    {
                        style = new GUIStyle(); style.fixedWidth = 64; style.fixedHeight = 64;
                        int terrainLayersCount = WT.MGP.terrain.terrainData.terrainLayers.Length;
                        if (WorldToolsParams.terrainLayers == null || WorldToolsParams.terrainLayers.Length == 0 || WorldToolsParams.terrainLayers.Length != terrainLayersCount) WorldToolsParams.terrainLayers = WT.MGP.terrain.terrainData.terrainLayers;
                        if (WT.exclusion == null || WT.exclusion.Length == 0 || WT.exclusion.Length != terrainLayersCount)
                        {
                            WT.exclusion = new float[terrainLayersCount];
                            for (int i = 0; i < WT.exclusion.Length; i++) WT.exclusion[i] = 0f;
                            serializedObject.ApplyModifiedProperties();
                            serializedObject.Update();
                        }

                        EditorGUI.BeginChangeCheck();
                        for (int i = 0; i < WT.MGP.exclusionOpacities.Length; i++)
                        {
                            GUILayout.Space(60);
                            WorldToolsParams.lastRect = GUILayoutUtility.GetLastRect();
                            WorldToolsParams.lastRect.x = (Screen.width / 2) - (64 / 2);
                            WorldToolsParams.lastRect.y += 30;
                            THelpersUIRuntime.GUI_Label(WorldToolsParams.terrainLayers[i].diffuseTexture, WorldToolsParams.lastRect, style);
                            GUILayout.Space(20);
                            EditorGUILayout.PropertyField(serializedObject.FindProperty("exclusion").GetArrayElementAtIndex(i), new GUIContent("EXCLUSION PERCENTAGE  %", "Filtering percentage to remove models based on this terrain layer's alphamap weight"));
                            WT.MGP.exclusionOpacities[i] = (100 - WT.exclusion[i]) / 100f;
                        }
                        if (EditorGUI.EndChangeCheck()) UpdatePlacementDelayed();
                    }

                    if (WorldToolsParams.painting) THelpersUIRuntime.GUI_HelpBox("\n\tPAINTING\t\n", MessageType.None, 0, Color.cyan);
                    if (WorldToolsParams.erasing) THelpersUIRuntime.GUI_HelpBox("\n\tERASING\t\n", MessageType.None, 0, Color.cyan);
                    GUILayout.Space(10);
                }
                else
                {
                    style = new GUIStyle(EditorStyles.toolbarButton);
                    style.fixedWidth = 128;
                    style.fixedHeight = 32;
                    THelpersUIRuntime.GUI_Button(new GUIContent("EDIT PLACEMENT", "Paint and edit placement in scene"), style, TBrushFunctions.EditPlacement);
                }

                GUILayout.Space(10);
            }
        }

        public virtual void OnDestroy()
        {
            TBrushFunctions.OnDestroy();
        }

        public virtual void UpdatePlacement() { }
        public virtual void UpdatePlacementDelayed() { }
    }
}
#endif

