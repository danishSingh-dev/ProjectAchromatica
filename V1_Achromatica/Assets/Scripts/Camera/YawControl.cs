using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFunction
{
    public class YawControl : MonoBehaviour
    {
        #region Variables

        [Header( "Utility" )]
        [SerializeField] private float _yawValue = 0f;

        [Header( "Settings" )]
        [SerializeField] private float _yawAxis = 0f;
        [SerializeField] private float _yawRotationSpeed = 10f;

        #endregion

        #region MonoBehaviour Methods

        private void Update( )
        {
            CalculateRotationAmount( );
        }

        private void FixedUpdate( )
        {
            ApplyRotationAmount( );
            
        }


        #endregion


        #region Custom Methods

        private void CalculateRotationAmount( )
        {
            _yawAxis += _yawValue * _yawRotationSpeed * Time.deltaTime;

        }

        private void ApplyRotationAmount( )
        {
            transform.localRotation = Quaternion.Euler( 0f , _yawAxis , 0f );

        }

        #endregion


        #region Event Functionality

        public void GetYawValue(float val )
        {
            _yawValue = val;
        }

        #endregion 
    }
}
