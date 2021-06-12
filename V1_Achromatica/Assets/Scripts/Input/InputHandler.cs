using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputFunction
{
    public class InputHandler : MonoBehaviour
    {
        #region Private Variables

        [SerializeField] private Vector2 leftStickVector = Vector2.zero;
        [SerializeField] private Vector2 rightStickVector = Vector2.zero;

        private bool crossButtonTap = false, crossButtonHold = false;
        private bool squareButtonTap = false, squareButtonHold = false;
        private bool triangleButtonTap = false, triangleButtonHold = false;
        private bool circleButtonTap = false, circleButtonHold = false;

        private bool leftDirPadTap = false, leftDirPadHold = false;
        private bool rightDirPadTap = false, rightDirPadHold = false;
        private bool upDirPadTap = false, upDirPadHold = false;
        private bool downDirPadTap = false, downDirPadHold = false;

        private bool leftBumperTap = false, leftBumperHold = false;
        private bool rightBumperTap = false, rightBumperHold = false;

        private bool leftTriggerTap = false, leftTriggerHold = false;
        private bool rightTriggerTap = false, rightTriggerHold = false;

        private bool leftStickTap = false, leftStickHold = false;
        private bool rightStickTap = false, rightStickHold = false;

        private bool optionsButtonTap = false;

        [SerializeField] private InputReceiver _inputReceiver;

        #endregion

        #region Public Getters


        public Vector2 LeftStickVector { get { return leftStickVector; } }
        public Vector2 RightStickVector { get { return rightStickVector; } }
        public bool SquareButtonTap {  get { return squareButtonTap; } }


        #endregion

        #region Event Accessors


        #endregion



        #region Monobehaviour Methods

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
            _inputReceiver.CameraMovement += OnCameraMove;

            _inputReceiver.LightAttackPerformed += OnLightAttackPerformed;
            _inputReceiver.LightAttackHeldStarted += OnLightAttackHeldStarted;
            _inputReceiver.LightAttackHeldPerformed += OnLightAttackHeldPerformed;
        }
        
        private void UnSubscribe( )
        {
            _inputReceiver.Movement -= OnMove;
            _inputReceiver.CameraMovement -= OnCameraMove;

            _inputReceiver.LightAttackPerformed -= OnLightAttackPerformed;
            _inputReceiver.LightAttackHeldStarted -= OnLightAttackHeldStarted;
            _inputReceiver.LightAttackHeldPerformed -= OnLightAttackHeldPerformed;
        }


        #endregion


        #region Movement and Camera Functionality

        private void OnMove( Vector2 vector )
        {
            leftStickVector = vector;
        }

        private void OnCameraMove( Vector2 vector )
        {
            rightStickVector = vector;
        }

        #endregion



        #region Light Attack Functionality

        // Tap
        private void OnLightAttackPerformed( )
        {
            Debug.Log( "Light Attack performed" );
        }

        // SlowTap start
        private void OnLightAttackHeldStarted( )
        {
            Debug.Log( "Charging Strong Light Attack" );
        }

        // SlowTap Performed
        private void OnLightAttackHeldPerformed( )
        {
            Debug.Log( "Strong Light Attack performed" );
        }

        #endregion



        //public void GetMovementVariables( float hor , float ver )
        //{
        //    leftStickVector.x = hor;
        //    leftStickVector.y = ver;
        //}

        //public void GetCameraMovementVariables( float camX , float camY )
        //{
        //    rightStickVector.x = camX;
        //    rightStickVector.y = camY;
        //}

        //public void GetLightAttackTap( InputAction.CallbackContext ctx)
        //{
        //    squareButtonTap = ctx.performed;
        //}

        //public void GetMovement( InputAction.CallbackContext ctx)
        //{
        //    Vector2 moveInput = ctx.ReadValue<Vector2>( );

        //    leftStickVector = moveInput;
        //}
    }
}
