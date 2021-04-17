#if UNITY_EDITOR
using UnityEngine;
using System.Collections.Generic;

namespace TerraUnity.Runtime
{
    public class WorldTools : WorldToolsParams
    {
        private Terrain _terrain;
        public bool affectGPULayers = true;
        public bool affectGrassLayers = true;
        public List<TScatterParams> GPULayers;
        public List<GrassLayer> grassLayers;
        public List<bool> editableGPU;
        public List<bool> editableGrass;
        public List<TScatterLayer.MaskData[]> maskDataListGPU;
        public List<float[]> exclusionOpacitiesListGPU;
        public List<TScatterLayer.MaskData[]> maskDataListGrass;
        public List<float[]> exclusionOpacitiesListGrass;

        public Terrain Terrain
        {
            get
            {
                if (_terrain == null && TTerraWorldManager.MainTerrainGO !=null ) _terrain = TTerraWorldManager.MainTerrainGO.GetComponent<Terrain>();
                return _terrain;
            }
        }

        //public Terrain Terrain 
        //{
        //    get 
        //    {
        //        if (_terrain == null)
        //        {
        //            Transform parent = transform;
        //
        //            while (parent != null)
        //            {
        //                if (parent.GetComponent<Terrain>() != null)
        //                {
        //                    _terrain = parent.GetComponent<Terrain>();
        //                    break;
        //                }
        //                else
        //                    parent = parent.transform.parent;
        //            }
        //        }
        //
        //        return _terrain;
        //    }
        //}
    }
}
#endif

