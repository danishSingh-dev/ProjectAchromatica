using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem;

namespace Danish.Input
{



    [Serializable]
    public class MoveInputEvent : UnityEvent<float, float> { }
    [Serializable]
    public class CameraInputEvent : UnityEvent<float, float> { }

    public class InputReceiver : MonoBehaviour
    {

        #region Variables

        [SerializeField] private BaseControls baseControls;
        [SerializeField] private MoveInputEvent moveInputEvent;
        [SerializeField] private CameraInputEvent cameraInputEvent;


        #endregion

        #region MonoBehaviours
        private void Awake()
        {
            baseControls = new BaseControls();

            baseControls.FreeRoam.Movement.performed += OnMovePerformed;
            baseControls.FreeRoam.Movement.canceled += OnMovePerformed;

            baseControls.FreeRoam.CameraControl.performed += OnCameraPerformed;
            baseControls.FreeRoam.CameraControl.canceled += OnCameraPerformed;

            baseControls.FreeRoam.LightAttack.performed += LightAttack_performed;
        }

        

        private void OnEnable()
        {
            baseControls.FreeRoam.Enable();
        }

        private void OnDisable()
        {
            baseControls.FreeRoam.Disable();
        }

        #endregion


        #region Callback Functions

        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            Vector2 moveInput = ctx.ReadValue<Vector2>();

            moveInputEvent.Invoke(moveInput.x, moveInput.y);
        }

        private void OnCameraPerformed(InputAction.CallbackContext ctx)
        {
            Vector2 changeInput = ctx.ReadValue<Vector2>();

            cameraInputEvent.Invoke(changeInput.x, changeInput.y);
        }

        private void LightAttack_performed( InputAction.CallbackContext obj )
        {
            Debug.Log( "Light Attack" );
        }


        #endregion


        #region Utility Functions

        

        #endregion

    }

}
