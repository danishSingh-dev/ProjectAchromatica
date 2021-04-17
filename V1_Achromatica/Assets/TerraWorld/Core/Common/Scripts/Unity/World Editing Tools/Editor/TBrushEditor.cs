#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System;
using TerraUnity.UI;

namespace TerraUnity.Runtime
{
    public class TBrushEditor : Editor
    {
        public WorldTools script { get => (WorldTools)target; } 

        public void MaskEditorGUI ()
        {
            //Repaint();

            if (script.maskDataListGPU != null || script.maskDataListGrass != null)
            {
                TBrushFunctions.WT = script;
                WorldToolsParams.globalMode = true;

                if (script.liveSyncState == 0) GUI.color = WorldToolsParams.liveSyncColor;
                else if (script.liveSyncState == 1) GUI.color = WorldToolsParams.bypassColor;
                THelpersUIRuntime.GUI_HelpBox(new GUIContent("LIVE SYNC MODE", "If enabled, all terrain heights sculpting or texture painting changes will be detected and TerraWorld layers will be synced and updated based on new changes"), true);
                GUI.color = Color.white;

                int liveSyncState = script.liveSyncState;
                EditorGUI.BeginChangeCheck();
                liveSyncState = THelpersUIRuntime.GUI_SelectionGrid(liveSyncState, WorldToolsParams.liveSyncSelection, new GUIStyle(EditorStyles.toolbarButton));
                if (EditorGUI.EndChangeCheck())
                {
                    script.liveSyncState = liveSyncState;
                    DetectTerrainChanges.liveSync = !Convert.ToBoolean(script.liveSyncState);
                }

                if (script.liveSyncState == 0)
                    THelpersUIRuntime.GUI_HelpBox("LAYERS WILL AUTO-UPDATE WHEN TERRAIN HEIGHTS/TEXTURES CHANGE", MessageType.Info, -5);
                else if (script.liveSyncState == 1)
                    THelpersUIRuntime.GUI_HelpBox("LAYERS WILL NOT BE UPDATED IF TERRAIN HEIGHTS/TEXTURES CHANGE!", MessageType.Warning, -5);

                GUIStyle style = new GUIStyle(EditorStyles.toolbarButton); style.fixedWidth = 128; style.fixedHeight = 32;

                if (WorldToolsParams.isEditMode)
                {
                    THelpersUIRuntime.GUI_Button(new GUIContent("EXIT EDIT MODE", "Finish editing placement"), style, TBrushFunctions.EditPlacement, 10, 0, Color.red);
                    THelpersUIRuntime.GUI_HelpBox(WorldToolsParams.editingText, MessageType.None);

                    int maximumBrushSize = (int)script.Terrain.terrainData.size.x / 4;
                    int minimumBrushSize = Mathf.Clamp(Mathf.CeilToInt(script.Terrain.terrainData.size.x / WorldToolsParams.dataWidthBrush), 1, maximumBrushSize);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("brushRadius"), new GUIContent("BRUSH RADIUS", "Brush Radius for painting and editing placement"));
                    script.brushRadius = Mathf.Clamp(script.brushRadius, minimumBrushSize, maximumBrushSize);
                    GUILayout.Space(5);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("brushDensity"), new GUIContent("BRUSH DENSITY", "Brush Density for painting and editing placement"));
                    GUILayout.Space(25);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("affectGPULayers"), new GUIContent("EDIT GPU LAYERS", "Activate this option to globally paint/erase placed GPU Layers in scene"));
                    GUILayout.Space(5);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("affectGrassLayers"), new GUIContent("EDIT GRASS LAYERS", "Activate this option to globally paint/erase placed Grass Layers in scene"));

                    if (!script.affectGPULayers && !script.affectGrassLayers)
                        THelpersUIRuntime.GUI_HelpBox("NO LAYERS WILL BE AFFECTED! SELECT AT LEAST 1 LAYER TYPE TO PAINT/ERASE!", MessageType.Warning);
                    else if (script.maskDataListGPU == null && script.maskDataListGrass == null)
                        THelpersUIRuntime.GUI_HelpBox("NO LAYERS ARE DETECTED IN SCENE!", MessageType.Warning);
                    else
                    {
                        if (script.affectGPULayers && script.maskDataListGPU == null)
                            THelpersUIRuntime.GUI_HelpBox("NO GPU LAYERS ARE DETECTED IN SCENE!", MessageType.Info);

                        if (script.affectGrassLayers && script.maskDataListGrass == null)
                            THelpersUIRuntime.GUI_HelpBox("NO GRASS LAYERS ARE DETECTED IN SCENE!", MessageType.Info);

                        if (!script.affectGPULayers && script.affectGrassLayers && script.maskDataListGrass == null) return;
                        if (!script.affectGrassLayers && script.affectGPULayers && script.maskDataListGPU == null) return;

                        if (script.affectGPULayers && script.maskDataListGPU != null)
                        {
                            GUILayout.Space(20);
                            WorldToolsParams.sectionToggle1 = THelpersUIRuntime.Foldout("LAYERS \"GPU\"", ref WorldToolsParams.sectionToggle1);

                            if (WorldToolsParams.sectionToggle1)
                            {
                                THelpersUIRuntime.GUI_HelpBox(new GUIContent("HIDE ALL LAYERS", "Hide all layers in this section"), true, 10);
                                EditorGUI.BeginChangeCheck();
                                WorldToolsParams.hideAllGPU = THelpersUIRuntime.GUI_SelectionGrid(WorldToolsParams.hideAllGPU, WorldToolsParams.liveSyncSelection, new GUIStyle(EditorStyles.toolbarButton));
                                if (EditorGUI.EndChangeCheck())
                                {
                                    if (WorldToolsParams.hideAllGPU == 0)
                                        TBrushFunctions.IsolatePreview(null, true, false);
                                    else if (WorldToolsParams.hideAllGPU == 1)
                                        TBrushFunctions.RevertPreview(null, true, false);
                                }

                                if (WorldToolsParams.hideAllGPU == 1)
                                {
                                    GUILayout.Space(15);

                                    for (int i = 0; i < script.GPULayers.Count + 1; i++)
                                    {
                                        if (i < script.GPULayers.Count)
                                        {
                                            bool layerEditingState = i != WorldToolsParams.isolatedIndexGPU && WorldToolsParams.isolatedIndexGPU != -1;
                                            EditorGUI.BeginDisabledGroup(layerEditingState); //Freeze layer based on the isolated layer
                                            THelpersUIRuntime.DrawUILine(THelpersUIRuntime.SubUIColor, 2, 20);
                                            GameObject layerObject = script.GPULayers[i].transform.parent.gameObject;

                                            EditorGUILayout.PropertyField(serializedObject.FindProperty("editableGPU").GetArrayElementAtIndex(i), new GUIContent("EDITABLE", "Is layer editable?"));

                                            int state = 0;
                                            if (!script.editableGPU[i]) state = 1;
                                            if (state == 0) GUI.color = WorldToolsParams.editableColor;
                                            else GUI.color = WorldToolsParams.bypassColor;
                                            EditorGUI.BeginChangeCheck();
                                            THelpersUIRuntime.GUI_SelectionGrid(state, WorldToolsParams.effectiveSelection, new GUIStyle(EditorStyles.toolbarButton));
                                            if (EditorGUI.EndChangeCheck()) script.editableGPU[i] = !Convert.ToBoolean(state);
                                            GUI.color = Color.white;

                                            GUILayout.Space(10);
                                            if (i == WorldToolsParams.isolatedIndexGPU || WorldToolsParams.isolatedIndexGPU == -1)
                                            {
                                                EditorGUI.BeginChangeCheck();
                                                GUILayout.Space(10);
                                                EditorGUILayout.PropertyField(serializedObject.FindProperty("isolateLayer"), new GUIContent("ISOLATE LAYER", "Isolate and only edit this layer"));
                                                if (EditorGUI.EndChangeCheck())
                                                {
                                                    serializedObject.ApplyModifiedProperties();
                                                    if (script.isolateLayer) WorldToolsParams.isolatedIndexGPU = i;
                                                    else WorldToolsParams.isolatedIndexGPU = -1;
                                                }
                                            }
                                            else GUILayout.Space(30);

                                            GUILayout.Space(10);

                                            EditorGUI.BeginDisabledGroup(!layerObject.activeSelf);
                                            if (script.GPULayers[i].Prefab != null)
                                            {
                                                if (!layerObject.activeSelf || layerEditingState) GUI.color = WorldToolsParams.disabledColor;
                                                else GUI.color = WorldToolsParams.enabledColor;
                                                ModelPreviewUI.ModelPreviewList(script.GPULayers[i].Prefab, new GUIStyle(EditorStyles.helpBox), 128);
                                                GUI.color = WorldToolsParams.enabledColor;
                                            }

                                            EditorGUILayout.BeginHorizontal();
                                            GUILayout.FlexibleSpace();
                                            THelpersUIRuntime.GUI_ObjectField(new GUIContent("Layer " + (i + 1).ToString(), "GPU Instance layer in scene"), layerObject, typeof(GameObject));
                                            GUILayout.FlexibleSpace();
                                            EditorGUILayout.EndHorizontal();
                                            EditorGUI.EndDisabledGroup();

                                            state = 0;
                                            if (!layerObject.activeSelf) state = 1;
                                            EditorGUI.BeginChangeCheck();
                                            state = THelpersUIRuntime.GUI_SelectionGrid(state, WorldToolsParams.onOffSelection, new GUIStyle(EditorStyles.toolbarButton));
                                            if (EditorGUI.EndChangeCheck()) layerObject.SetActive(!Convert.ToBoolean(state));

                                            style = new GUIStyle(EditorStyles.toolbarButton); style.fixedWidth = 40; style.fixedHeight = 20;
                                            style.alignment = TextAnchor.MiddleCenter;
                                            style.fontSize = 30;

                                            GUILayout.Space(20);
                                            EditorGUILayout.BeginHorizontal();
                                            GUILayout.FlexibleSpace();
                                            if (GUILayout.Button(new GUIContent("-", "Remove layer"), style))
                                            {
                                                TBrushFunctions.RemoveLayer(layerObject);
                                            }
                                            GUILayout.FlexibleSpace();
                                            EditorGUILayout.EndHorizontal();

                                            GUILayout.Space(40);
                                            EditorGUI.EndDisabledGroup(); //Freeze layer based on the isolated layer
                                        }
                                        else
                                        {
                                            //THelpersUIRuntime.DrawUILine(THelpersUIRuntime.SubUIColor, 2, 20);
                                            //style = new GUIStyle(EditorStyles.toolbarButton); style.fixedWidth = 100; style.fixedHeight = 40;
                                            //style.alignment = TextAnchor.MiddleCenter;
                                            //style.fontSize = 40;
                                            //THelpersUIRuntime.GUI_Button(new GUIContent("+", "Add layer"), style, AddLayer, 20);
                                        }
                                    }
                                }
                            }
                        }

                        if (script.affectGrassLayers && script.maskDataListGrass != null)
                        {
                            if (!script.affectGPULayers || script.maskDataListGPU == null) GUILayout.Space(20);
                            WorldToolsParams.sectionToggle2 = THelpersUIRuntime.Foldout("LAYERS \"GRASS\"", ref WorldToolsParams.sectionToggle2);

                            if (WorldToolsParams.sectionToggle2)
                            {
                                THelpersUIRuntime.GUI_HelpBox(new GUIContent("HIDE ALL LAYERS", "Hide all layers in this section"), true, 10);
                                EditorGUI.BeginChangeCheck();
                                WorldToolsParams.hideAllGrass = THelpersUIRuntime.GUI_SelectionGrid(WorldToolsParams.hideAllGrass, WorldToolsParams.liveSyncSelection, new GUIStyle(EditorStyles.toolbarButton));
                                if (EditorGUI.EndChangeCheck())
                                {
                                    if (WorldToolsParams.hideAllGrass == 0)
                                        TBrushFunctions.IsolatePreview(null, false, true);
                                    else if (WorldToolsParams.hideAllGrass == 1)
                                        TBrushFunctions.RevertPreview(null, false, true);
                                }

                                if (WorldToolsParams.hideAllGrass == 1)
                                {
                                    GUILayout.Space(15);

                                    for (int i = 0; i < script.grassLayers.Count; i++)
                                    {
                                        bool layerEditingState = i != WorldToolsParams.isolatedIndexGrass && WorldToolsParams.isolatedIndexGrass != -1;
                                        EditorGUI.BeginDisabledGroup(layerEditingState); //Freeze layer based on selected isolated layer
                                        THelpersUIRuntime.DrawUILine(THelpersUIRuntime.SubUIColor, 2, 20);
                                        GameObject layerObject = script.grassLayers[i].transform.gameObject;

                                        EditorGUILayout.PropertyField(serializedObject.FindProperty("editableGrass").GetArrayElementAtIndex(i), new GUIContent("EDITABLE", "Is layer editable?"));

                                        int state = 0;
                                        if (!script.editableGrass[i]) state = 1;
                                        if (state == 0) GUI.color = WorldToolsParams.editableColor;
                                        else GUI.color = WorldToolsParams.bypassColor;
                                        EditorGUI.BeginChangeCheck();
                                        THelpersUIRuntime.GUI_SelectionGrid(state, WorldToolsParams.effectiveSelection, new GUIStyle(EditorStyles.toolbarButton));
                                        if (EditorGUI.EndChangeCheck()) script.editableGrass[i] = !Convert.ToBoolean(state);
                                        GUI.color = Color.white;

                                        GUILayout.Space(10);
                                        if (i == WorldToolsParams.isolatedIndexGrass || WorldToolsParams.isolatedIndexGrass == -1)
                                        {
                                            EditorGUI.BeginChangeCheck();
                                            GUILayout.Space(10);
                                            EditorGUILayout.PropertyField(serializedObject.FindProperty("isolateLayer"), new GUIContent("ISOLATE LAYER", "Isolate and only edit this layer"));
                                            if (EditorGUI.EndChangeCheck())
                                            {
                                                serializedObject.ApplyModifiedProperties();
                                                if (script.isolateLayer) WorldToolsParams.isolatedIndexGrass = i;
                                                else WorldToolsParams.isolatedIndexGrass = -1;
                                            }
                                        }
                                        else GUILayout.Space(30);

                                        GUILayout.Space(10);

                                        EditorGUI.BeginDisabledGroup(!layerObject.activeSelf);
                                        if (script.grassLayers[i].MGP.Material != null)
                                        {
                                            if (!layerObject.activeSelf || layerEditingState) GUI.color = WorldToolsParams.disabledColor;
                                            else GUI.color = WorldToolsParams.enabledColor;
                                            ModelPreviewUI.ModelPreviewList(script.grassLayers[i].MGP.Material, new GUIStyle(EditorStyles.helpBox), 128);
                                            GUI.color = WorldToolsParams.enabledColor;
                                        }

                                        EditorGUILayout.BeginHorizontal();
                                        GUILayout.FlexibleSpace();
                                        THelpersUIRuntime.GUI_ObjectField(new GUIContent("Layer " + (i + 1).ToString(), "Grass layer in scene"), layerObject, typeof(GameObject));
                                        GUILayout.FlexibleSpace();
                                        EditorGUILayout.EndHorizontal();
                                        EditorGUI.EndDisabledGroup();

                                        state = 0;
                                        if (!layerObject.activeSelf) state = 1;
                                        EditorGUI.BeginChangeCheck();
                                        state = THelpersUIRuntime.GUI_SelectionGrid(state, WorldToolsParams.onOffSelection, new GUIStyle(EditorStyles.toolbarButton));
                                        if (EditorGUI.EndChangeCheck())
                                        {
                                            layerObject.SetActive(!Convert.ToBoolean(state));
                                            script.grassLayers[i].active = !Convert.ToBoolean(state);
                                            script.grassLayers[i].massiveGrass.Refresh();
                                        }

                                        GUILayout.Space(40);
                                        EditorGUI.EndDisabledGroup(); //Freeze layer based on the isolated layer
                                    }
                                }
                            }
                        }

                        GUILayout.Space(20);
                        WorldToolsParams.sectionToggle3 = THelpersUIRuntime.Foldout("TERRAIN LAYERS (TEXTURES) FILTERING", ref WorldToolsParams.sectionToggle3);

                        if (WorldToolsParams.sectionToggle3)
                        {
                            style = new GUIStyle(); style.fixedWidth = 64; style.fixedHeight = 64;
                            int terrainLayersCount = script.Terrain.terrainData.terrainLayers.Length;
                            if (WorldToolsParams.terrainLayers == null || WorldToolsParams.terrainLayers.Length == 0 || WorldToolsParams.terrainLayers.Length != terrainLayersCount) WorldToolsParams.terrainLayers = script.Terrain.terrainData.terrainLayers;
                            
                            if (script.exclusionGPU == null || script.exclusionGPU.Length == 0 || script.exclusionGPU.Length != terrainLayersCount)
                            {
                                script.exclusionGPU = new float[terrainLayersCount];
                                for (int i = 0; i < script.exclusionGPU.Length; i++) script.exclusionGPU[i] = 0f;
                                serializedObject.ApplyModifiedProperties();
                                serializedObject.Update();
                            }

                            if (script.exclusionGrass == null || script.exclusionGrass.Length == 0 || script.exclusionGrass.Length != terrainLayersCount)
                            {
                                script.exclusionGrass = new float[terrainLayersCount];
                                for (int i = 0; i < script.exclusionGrass.Length; i++) script.exclusionGrass[i] = 0f;
                                serializedObject.ApplyModifiedProperties();
                                serializedObject.Update();
                            }

                            for (int i = 0; i < terrainLayersCount; i++)
                            {
                                GUILayout.Space(60);
                                WorldToolsParams.lastRect = GUILayoutUtility.GetLastRect();
                                WorldToolsParams.lastRect.x = (Screen.width / 2) - (64 / 2);
                                WorldToolsParams.lastRect.y += 30;
                                THelpersUIRuntime.GUI_Label(WorldToolsParams.terrainLayers[i].diffuseTexture, WorldToolsParams.lastRect, style);
                                int space = 20;

                                EditorGUI.BeginChangeCheck();
                                if (script.affectGPULayers)
                                {
                                    for (int j = 0; j < script.exclusionOpacitiesListGPU.Count; j++)
                                    {
                                        if (j == 0)
                                        {
                                            GUILayout.Space(space);
                                            EditorGUILayout.PropertyField(serializedObject.FindProperty("exclusionGPU").GetArrayElementAtIndex(i), new GUIContent("GPU LAYER EXCLUSION  %", "Filtering percentage to remove models based on this terrain layer's alphamap weight"));
                                        }
                                        
                                        if (script.exclusionOpacitiesListGPU[j] != null && script.exclusionOpacitiesListGPU[j].Length == terrainLayersCount)
                                            script.exclusionOpacitiesListGPU[j][i] = (100 - script.exclusionGPU[i]) / 100f;
                                    }
                                }
                                if (EditorGUI.EndChangeCheck()) TBrushFunctions.SyncDelayedGPU();

                                if (script.affectGrassLayers && script.affectGPULayers) space = 0;

                                EditorGUI.BeginChangeCheck();
                                if (script.affectGrassLayers)
                                {
                                    for (int j = 0; j < script.exclusionOpacitiesListGrass.Count; j++)
                                    {
                                        if (j == 0)
                                        {
                                            GUILayout.Space(space);
                                            EditorGUILayout.PropertyField(serializedObject.FindProperty("exclusionGrass").GetArrayElementAtIndex(i), new GUIContent("GRASS EXCLUSION  %", "Filtering percentage to remove models based on this terrain layer's alphamap weight"));
                                        }

                                        if (script.exclusionOpacitiesListGrass[j] != null && script.exclusionOpacitiesListGrass[j].Length == terrainLayersCount)
                                            script.exclusionOpacitiesListGrass[j][i] = (100 - script.exclusionGrass[i]) / 100f;
                                    }
                                }
                                if (EditorGUI.EndChangeCheck()) TBrushFunctions.SyncDelayedGrass();
                            }
                        }

                        style = new GUIStyle(EditorStyles.toolbarButton); style.fixedWidth = 128; style.fixedHeight = 20;
                        THelpersUIRuntime.GUI_Button(new GUIContent("FORCE UPDATE", "Force update & sync all layers' placement"), style, TBrushFunctions.SyncAllLayers, 40);
                        THelpersUIRuntime.GUI_Button(new GUIContent("REFRESH LAYERS", "Refresh layers list for latest scene changes"), style, TBrushFunctions.RefreshLayers);

                        if (WorldToolsParams.painting) THelpersUIRuntime.GUI_HelpBox("\n\tPAINTING\t\n", MessageType.None, 0, Color.cyan);
                        if (WorldToolsParams.erasing) THelpersUIRuntime.GUI_HelpBox("\n\tERASING\t\n", MessageType.None, 0, Color.cyan);
                        GUILayout.Space(10);
                    }
                }
                else
                {
                    style = new GUIStyle(EditorStyles.toolbarButton);
                    style.fixedWidth = 128;
                    style.fixedHeight = 32;
                    THelpersUIRuntime.GUI_Button(new GUIContent("EDIT WORLD", "Paint and edit placement in scene"), style, TBrushFunctions.EditPlacement, 10);
                }

                GUILayout.Space(20);
            }
        }

        public void OnDestroy()
        {
            TBrushFunctions.OnDestroy();
        }
    }
}
#endif

