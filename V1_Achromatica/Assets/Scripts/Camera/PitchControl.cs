using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraFunction
{
    public class PitchControl : MonoBehaviour
    {
        #region Variables

        [Header( "Utility" )]
        [SerializeField] private float _pitchValue = 0f;

        [Header( "Settings" )]
        [SerializeField] private float _pitchAxis = 0f;
        [SerializeField] private float _pitchRotationSpeed = 10f;
        [SerializeField] private float _pitchMinAngle = -10f;
        [SerializeField] private float _pitchMaxAngle = 35f;

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
            _pitchAxis += _pitchValue * _pitchRotationSpeed * Time.deltaTime;
            _pitchAxis = Mathf.Clamp( _pitchAxis , _pitchMinAngle , _pitchMaxAngle );
        }

        private void ApplyRotationAmount( )
        {
            transform.localRotation = Quaternion.Euler( _pitchAxis , 0f , 0f );
        }

        #endregion



        #region Event Functionality

        public void GetPitchValue(float val )
        {
            _pitchValue = val;
        }

        #endregion
    }
}
