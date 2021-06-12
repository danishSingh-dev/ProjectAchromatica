using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

using InputFunction;

namespace CameraFunction
{
    [Serializable]
    public class YawControlEvent : UnityEvent<float> { }
    [Serializable]
    public class PitchControlEvent : UnityEvent<float> { }

    public class ThirdPersonCamera : MonoBehaviour
    {
        #region Variables
        [Header( "Events" )]
        // reference to event to alter the Yaw Axis of the camera rig (X)
        [SerializeField] private YawControlEvent yawControlEvent;
        // reference to event to alter the Pitch Axis of the camera rig (Y)
        [SerializeField] private PitchControlEvent pitchControlEvent;

        [Header("Components")]
        // reference to the InputReceiver Component
        [SerializeField] private InputReceiver _inputReceiver = null;
        // reference to Player's transform
        [SerializeField] private Transform _player = null;
        // reference to Camera Component
        [SerializeField] private Camera _camera = null;
        // reference to Camera Transform
        [SerializeField] private Transform _camTransform = null;


        [Header( "Camera Settings" )]
        // Camera Transform's Z position
        [SerializeField] private float _camDistance = 5f;
        // Camera Transform's Y position
        [SerializeField] private float _camHeight = 1.75f;
        // Camera Transform's X position
        [SerializeField] private float _camOffset = 1f;
        // utility bool to update camera settings during Play session
        [SerializeField] private bool _updateCamera = false;

        

        [Header( "Smoothing Settings" )]
        // Minimum distance between Camera and Target
        [SerializeField] private float _distanceBetween = 0.1f;
        // Speed of smoothing 
        [SerializeField] private float _smoothingFactor = 2f;


        [Header( "Utility" )]
        // input on the horizontal axis
        [SerializeField] private float _horizontal = 0f;
        // input on the vertical axis
        [SerializeField] private float _vertical = 0f;

        #endregion



        #region MonoBehaviour Methods

        private void Start( )
        {
            // Get reference to [_player]
            _player = GameObject.FindGameObjectWithTag( "Player" ).transform;

            // Get Camera component and assign [_camTransform] variable
            _camera = (Camera) GetComponentInChildren( typeof( Camera ) );
            _camTransform = _camera.transform;


            // Setup Camera according to "Camera Settings"
            _camTransform.localPosition = ( Vector3.zero + ( Vector3.back * _camDistance ) );
            _camTransform.localPosition += ( Vector3.up * _camHeight );
            _camTransform.localPosition += ( Vector3.right * _camOffset );
        }

        private void Update( )
        {
            // Update camera position if changed during play session
            UpdateCameraPosition( );


            // Get camere movement input from [_inputHandler]
            //GetCameraMovementInput( );


            // Send the [_horizontal] value to [YawControl]
            SetYawValue( );
            // Send the [_vertical] value to [PitchControl]
            SetPitchValue( );

        }

        private void FixedUpdate( )
        {
            // Calculate distance between Camera Rig and [_player]
            CameraMovementFunctionality( );
            
        }

        private void OnEnable( )
        {
            Subscribe( );
        }

        private void OnDisable( )
        {
            UnSubscribe( );
        }

        #endregion

        #region Event Subscription

        private void Subscribe( )
        {
            _inputReceiver.CameraMovement += OnCameraMove;
        }

        private void UnSubscribe( )
        {
            _inputReceiver.CameraMovement -= OnCameraMove;
        }

        #endregion


        #region Utility Methods

        private void UpdateCameraPosition( )
        {
            if ( _updateCamera )
            {
                _camTransform.localPosition = ( Vector3.zero + ( Vector3.back * _camDistance ) );
                _camTransform.localPosition += ( Vector3.up * _camHeight );
                _camTransform.localPosition += ( Vector3.right * _camOffset );
            }

            _updateCamera = false;
        }

        //private void GetCameraMovementInput( )
        //{
        //    Vector2 vector = Vector2.zero;
        //    vector = _inputHandler.RightStickVector;

        //    _horizontal = vector.x;
        //    _vertical = vector.y;
        //}


        private void OnCameraMove(Vector2 vector )
        {
            _horizontal = vector.x;
            _vertical = vector.y;
        }

        private void CameraMovementFunctionality( )
        {
            float distanceBetween = 0f;
            distanceBetween = Vector3.Distance( transform.position , _player.position );

            if ( distanceBetween > _distanceBetween )
            {
                transform.position = Vector3.Lerp( transform.position , _player.position , _smoothingFactor * Time.fixedDeltaTime );
            }
        }

        #endregion




        #region Event Functionality

        private void SetYawValue( )
        {
            yawControlEvent.Invoke( _horizontal );
        }

        private void SetPitchValue( )
        {
            pitchControlEvent.Invoke( _vertical );
        }

        #endregion
    }
}
