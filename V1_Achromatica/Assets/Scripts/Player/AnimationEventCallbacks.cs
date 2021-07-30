using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerFunction
{
    public class AnimationEventCallbacks : MonoBehaviour
    {
        private ThirdPersonPlayerController playerController = null;



        public void Start( )
        {
            playerController = gameObject.GetComponentInParent< ThirdPersonPlayerController >();
        }
        public void DrawWeapon( )
        {
            Debug.Log( "Draw weapon" );
            playerController.WeaponDrawn( );
        }

        public void SheatheWeapon( )
        {
            Debug.Log( "Sheathe weapon" );
            playerController.WeaponSheathed( );
        }
    }
}
