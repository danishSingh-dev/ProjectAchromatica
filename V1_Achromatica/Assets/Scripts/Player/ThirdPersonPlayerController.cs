using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputFunction;

namespace PlayerFunction
{
    public class ThirdPersonPlayerController : MonoBehaviour
    {
        #region Variables

        [Header( "Components" )]
        [SerializeField] private InputReceiver _inputReceiver = null;
        [SerializeField] private Rigidbody _rigidbody = null;

        [Header( "Settings" )]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _moveSmoothing = 2f;
        [SerializeField] private float _rotationSmoothing = 5f;

        [Header( "Utility" )]
        [SerializeField] private float _horizontal = 0f;
        [SerializeField] private float _vertical = 0f;
        [SerializeField] private Vector3 _moveDirection = Vector3.zero;
        [SerializeField] private Quaternion _rotationToCamera = Quaternion.Euler( Vector3.zero );

        #endregion



        #region MonoBehaviour Methods

        private void Update( )
        {
            //GetMovementInput( );

            CalculateMoveDirection( );
        }

        private void FixedUpdate( )
        {
            MovePlayerWithTransform( );
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
            _inputReceiver.Movement += OnMove;
        }

        private void UnSubscribe( )
        {
            _inputReceiver.Movement -= OnMove;
        }

        #endregion



        #region Utility Methods

        //private void GetMovementInput( )
        //{
        //    Vector2 vector = Vector2.zero;
        //    vector = _inputHandler.LeftStickVector;

        //    _horizontal = vector.x;
        //    _vertical = vector.y;
        //}


        private void OnMove( Vector2 vector )
        {
            _horizontal = vector.x;
            _vertical = vector.y;
        }


        private void CalculateMoveDirection( )
        {
            _moveDirection = ( Vector3.forward * _vertical ) + ( Vector3.right * _horizontal );

            Vector3 projectedCameraForward = Vector3.ProjectOnPlane( Camera.main.transform.forward , Vector3.up );
            _rotationToCamera = Quaternion.LookRotation( projectedCameraForward , Vector3.up );

            _moveDirection = _rotationToCamera * _moveDirection;
        }

        private void MovePlayerWithTransform( )
        {
            Vector3 newPosition = transform.position + ( _moveDirection * _moveSpeed * Time.fixedDeltaTime );

            float difference = Vector3.Distance( transform.position , newPosition );


            transform.position = Vector3.Lerp( transform.position , newPosition , _moveSmoothing);

            if(difference > 0.01f)
            {
                transform.rotation = Quaternion.Slerp( transform.rotation , _rotationToCamera , _rotationSmoothing * Time.fixedDeltaTime );
            }
        }
        #endregion
    }
}
