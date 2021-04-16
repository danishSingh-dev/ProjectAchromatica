#if TERRAWORLD_XPRO
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine;
using TerraUnity;
using System.Collections.Generic;
using UnityEditor;
using TerraUnity.Edittime;
using UnityEngine.UI;

namespace TerraUnity.Graph
{
    [CreateNodeMenu("Generator/Tree Scatter")]
    public class TXTreeScatterNode : TXObjectScatterModules
    {

        [Input(ShowBackingValue.Never, ConnectionType.Override, TypeConstraint.Strict)]
        public TXMaskModules Input;


        public string prefabName;
        public UnityEngine.GameObject prefab = null;
        public int seedNo;
        public int densityResolutionPerKilometer = 500;
        public bool bypassLakes = true;
        public bool underLakes = false;
        public bool underLakesMask = false;
        public bool onLakes = false;
        public float minRotationRange = 0f;
        public float maxRotationRange = 359f;
        public float positionVariation = 100f;
        public System.Numerics.Vector3 scaleMultiplier = System.Numerics.Vector3.One;
        public float minScale = 0.8f;
        public float maxScale = 1.5f;
        public float minSlope = 0;
        public float maxSlope = 90;
        public int priority = 0;
        public System.Numerics.Vector3 objectScale = System.Numerics.Vector3.One;
        public float minRange = 0;
        public float maxRange = 1;
        public string unityLayerName = "Default";
        public int maskLayer = ~0;
        public string layerName;
        TMask _mask = null;
        public bool isWorldOffset = true;


        protected override void Init()
        {
            base.Init();
            SetName("Tree Scatter");
        }


        public override TObjectScatterLayer GetObjectsLayer(TTerrain terrain)
        {

            if (!IsActive) return null;
            if (IsDone) return _objectScatterLayer;

            return _objectScatterLayer;
        }


        public override void CheckEssentioalInputs()
        {
            var iv = GetInputValue<TXNode>("Input");
            if (iv == null) throw new Exception("Input" + " is missed for " + NodeName + " Node.");
            if (prefab == null) throw new Exception("Prefab parameter" + " is missed for " + NodeName + " Node.");

        }

    }


}
#endif