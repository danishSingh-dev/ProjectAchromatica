using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

namespace InputFunction
{
    

    public class InputReceiver : MonoBehaviour
    {
        #region Variables

        // Movement and Camera
        public event System.Action<Vector2> Movement;
        public event System.Action<Vector2> CameraMovement;


        // Light Attack - Tap and SlowTap Interactions
        public event System.Action LightAttackPerformed;
        public event System.Action LightAttackHeldStarted;
        public event System.Action LightAttackHeldPerformed;


        // Heavy Attack - Tap and SlowTap Interactions
        public event System.Action HeavyAttackPerformed;
        public event System.Action HeavyAttackHeldStarted;
        public event System.Action HeavyAttackHeldPerformed;

        // Ranged Attack - Tap and Hold Interactions
        public event System.Action RangedAttackPerformed;
        public event System.Action<float> RangedAttackHeldStarted;
        public event System.Action RangedAttackHeldPerformed;
        public event System.Action RangedAttackHeldCanceled;


        // InputActionsAsset
        private BaseControls _controls;

        #endregion



        #region MonoBehaviours

        private void Awake( )
        {
            _controls = new BaseControls( );
        }

        private void Start( )
        {
            _controls.FreeRoam.Movement.performed += OnMovement;
            _controls.FreeRoam.Movement.canceled += OnMovement;

            _controls.FreeRoam.CameraControl.performed += OnCameraMovement;
            _controls.FreeRoam.CameraControl.canceled += OnCameraMovement;

            _controls.FreeRoam.LightAttack.started += LightAttack_started;
            _controls.FreeRoam.LightAttack.performed += LightAttack_performed;

            _controls.FreeRoam.HeavyAttack.started += HeavyAttack_started;
            _controls.FreeRoam.HeavyAttack.performed += HeavyAttack_performed;

            _controls.FreeRoam.RangedAttack.started += RangedAttack_started;
            _controls.FreeRoam.RangedAttack.performed += RangedAttack_performed;
            _controls.FreeRoam.RangedAttack.canceled += RangedAttack_canceled;
            
        }

        

        private void OnEnable( )
        {
            _controls.Enable( );
        }

        private void OnDisable( )
        {
            _controls.Disable( );
        }
        #endregion








        #region Event Callback Functions

        private void OnMovement( InputAction.CallbackContext context )
        {
            Vector2 vector = context.ReadValue<Vector2>( );

            Movement?.Invoke( vector );
        }

        private void OnCameraMovement( InputAction.CallbackContext context )
        {
            Vector2 vector = context.ReadValue<Vector2>( );

            CameraMovement?.Invoke( vector );
        }





        private void LightAttack_started( InputAction.CallbackContext context )
        {
            if(context.interaction is SlowTapInteraction )
            {
                LightAttackHeldStarted?.Invoke( );
            }
        }

        private void LightAttack_performed( InputAction.CallbackContext context )
        {
            if(context.interaction is SlowTapInteraction )
            {
                LightAttackHeldPerformed?.Invoke( );
            }
            else
            {
                LightAttackPerformed?.Invoke( );
            }
        }






        private void HeavyAttack_started( InputAction.CallbackContext context )
        {
            if(context.interaction is SlowTapInteraction )
            {
                HeavyAttackHeldStarted?.Invoke( );
            }
        }

        private void HeavyAttack_performed( InputAction.CallbackContext context )
        {
            if(context.interaction is SlowTapInteraction )
            {
                HeavyAttackHeldPerformed?.Invoke( );
            }
            else
            {
                HeavyAttackPerformed?.Invoke( );
            }
        }






        private void RangedAttack_started( InputAction.CallbackContext context )
        {
            if(context.interaction is HoldInteraction )
            {
                float holdDuration = ( (HoldInteraction) context.interaction ).duration;

                RangedAttackHeldStarted?.Invoke( holdDuration );
            }
        }

        private void RangedAttack_performed( InputAction.CallbackContext context )
        {
            if(context.interaction is HoldInteraction )
            {
                RangedAttackHeldPerformed?.Invoke( );
            }
            else
            {
                RangedAttackPerformed?.Invoke( );
            }

        }

        private void RangedAttack_canceled( InputAction.CallbackContext context )
        {
            if(context.interaction is HoldInteraction )
            {
                RangedAttackHeldCanceled?.Invoke( );
            }
        }

        #endregion

    }
}
