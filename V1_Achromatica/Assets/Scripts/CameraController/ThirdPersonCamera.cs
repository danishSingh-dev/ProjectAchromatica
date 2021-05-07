using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Danish.Input;

namespace Danish.CameraController
{



    public class ThirdPersonCamera : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private InputHandler inputHandler = null;
        [SerializeField] private Transform cameraTarget = null;
        [SerializeField] private Transform playerCameraTarget = null;
        [SerializeField] private Transform cameraPivot = null;



        [Header("Rotation Settings")]
        [SerializeField] private float rotationSpeedX = 10f;
        [SerializeField] private float rotationSpeedY = 5f;
        [SerializeField] private float maxYAngle = 50f;
        [SerializeField] private float minYAngle = -10f;

        [Header("Movement Settings")]
        [SerializeField] private float followSpeed = 5f;
        [SerializeField] private float distanceToTarget = 5f;
        [SerializeField] private float maxDistanceBetweenTargets = 0.1f;
        [SerializeField] private float smoothingFactor = 2f;


        private Camera _camera = null;
        private Transform _camTransform = null;


        // Rotation Handling Variables
        private float axisX, axisY;
        private float _horizontal, _vertical;

        // Movement Handling Variables
        private Vector3 playerTargetCurrentPosition = Vector3.zero;
        private Vector3 cameraTargetCurrentPosition = Vector3.zero;
        private bool updateTargetPosition = false;
        

        #region MonoBehaviour Methods

        private void Awake()
        {
            _camera = Camera.main;
            _camTransform = _camera.transform;
        }

        private void Start( )
        {
            // Align target on CameraRig with target on PlayerObject
            AlignCameraTarget( );

            MoveCameraToDesignatedDistance( );

            // Assign target position
            cameraTargetCurrentPosition = cameraTarget.position;
            playerTargetCurrentPosition = playerCameraTarget.position;
        }

        private void Update( )
        {
            playerTargetCurrentPosition = playerCameraTarget.position;

            if(DistanceBetweenTargets() > maxDistanceBetweenTargets )
            {
                updateTargetPosition = true;
            }
            else
            {
                updateTargetPosition = false;
            }

            // Get assigned camera movement input and set horizontal and vertical variables
            GetCameraMovementInput( );

            // Process horizontal and vertical values to get delta axis rotation values to apply to pivot
            CalculateRotationValues( );
        }

        private void FixedUpdate()
        {
            // Implement Camera rotation and movement
            CameraRotationFunctionality();

            if ( updateTargetPosition )
            {
                CameraMovementFunctionality( );
            }
            
            cameraTargetCurrentPosition = cameraTarget.position;
        }

        #endregion


        #region Initialization Methods

        private void AlignCameraTarget( )
        {
            if(cameraTarget == null || playerCameraTarget == null )
            { return; }

            cameraTarget.position = playerCameraTarget.position;
        }

        private void MoveCameraToDesignatedDistance( )
        {
            _camTransform.position = playerCameraTarget.position;
            _camTransform.localPosition += ( Vector3.back * distanceToTarget );
        }

        #endregion


        #region Rotation Functionality

        private void GetCameraMovementInput( )
        {
            Vector2 vector = Vector2.zero;
            vector = inputHandler.RightStickVector;

            _horizontal = vector.x;
            _vertical = vector.y;
        }

        private void CalculateRotationValues( )
        {
            // Check to make sure a camera pivot is assigned
            if ( cameraPivot == null )
            { return; }

            HorizontalRotationValue( );
            VerticalRotationValue( );
        }

        private void HorizontalRotationValue( )
        {
            axisY += _horizontal * rotationSpeedX * Time.deltaTime;
        }

        private void VerticalRotationValue( )
        {
            axisX += _vertical * rotationSpeedY * Time.deltaTime;
            axisX = Mathf.Clamp( axisX , minYAngle , maxYAngle);
        }


        private void CameraRotationFunctionality()
        {
            cameraPivot.rotation = Quaternion.Euler( axisX , axisY , 0f );
        }

        #endregion

        #region Movement Functionality

        private float DistanceBetweenTargets( )
        {
            float distanceBetween = 0f;
            distanceBetween = Vector3.Distance( playerTargetCurrentPosition , cameraTargetCurrentPosition );

            return distanceBetween;
        }



        private void CameraMovementFunctionality( )
        {
            cameraTarget.position = Vector3.Lerp( cameraTarget.position , playerCameraTarget.position , smoothingFactor * Time.fixedDeltaTime );
        }
        #endregion
    }
}