using UnityEngine;

namespace TerraUnity.Runtime
{
    public class TTerraWorldTerrainManager : MonoBehaviour
    {

        private static Terrain mainTerrain;
        public Terrain MainTerrain { get => GetMainTerrain(); }
  
        private static Material terrainMaterial;
        public Material TerrainMaterial { get => GetTerrainMaterial(); }

        private static Material terrainMaterialBG;
        public Material TerrainMaterialBG { get => GetTerrainMaterialBG(); }

        private Terrain GetMainTerrain()
        {
            if (mainTerrain != null) return mainTerrain;
            mainTerrain = GetComponent<Terrain>();
            return mainTerrain;
        }

        private Material GetTerrainMaterial()
        {
            if (terrainMaterial != null) return terrainMaterial;
            Terrain worldTerrain = GetComponent<Terrain>();

            if (worldTerrain.materialTemplate != null)
                terrainMaterial = worldTerrain.materialTemplate;

            return terrainMaterial;
        }

        public static void SetTerrainMaterial(Terrain terrain, Material material)
        {
          //if (terrainMaterial == material) return ;
          
          if (terrain == null)
              throw new System.Exception("No Terrain Component Found! (SetTerrainMaterial)");
#if !UNITY_2019_1_OR_NEWER
            terrain.materialType = Terrain.MaterialType.Custom;
#endif
            terrain.materialTemplate = material;
          
          terrainMaterial = material;

        }

        public static void SetTerrainMaterialBG(Terrain terrain, Material material)
        {
           // if (terrainMaterialBG == material) return;

            if (terrain == null)
                throw new System.Exception("No Terrain Component Found! (SetTerrainMaterialBG)");
#if !UNITY_2019_1_OR_NEWER
            terrain.materialType = Terrain.MaterialType.Custom;
#endif
            terrain.materialTemplate = material;

            terrainMaterialBG = material;

        }

        private Material GetTerrainMaterialBG()
        {
            if (terrainMaterialBG != null) return terrainMaterialBG;
            Terrain worldTerrainBG = transform.Find("Background Terrain")?.gameObject.GetComponent<Terrain>();

            if (worldTerrainBG != null && worldTerrainBG.materialTemplate != null)
                terrainMaterialBG = worldTerrainBG.materialTemplate;

            return terrainMaterialBG;
        }
    }
}

