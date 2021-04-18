using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.InputSystem;

namespace Danish.Input
{



    [Serializable]
    public class MoveInputEvent : UnityEvent<float, float> { }

    public class InputReceiver : MonoBehaviour
    {
        [SerializeField] private BaseControls baseControls;
        [SerializeField] private Text leftStickText = null;
        [SerializeField] private MoveInputEvent moveInputEvent;

        private void Awake()
        {
            baseControls = new BaseControls();

            baseControls.FreeRoam.Movement.performed += OnMovePerformed;
            baseControls.FreeRoam.Movement.canceled += OnMovePerformed;
        }

        private void OnEnable()
        {
            baseControls.FreeRoam.Enable();
        }

        private void OnDisable()
        {
            baseControls.FreeRoam.Disable();
        }


        private void OnMovePerformed(InputAction.CallbackContext ctx)
        {
            Vector2 moveInput = ctx.ReadValue<Vector2>();
            leftStickText.text = moveInput.ToString();

            moveInputEvent.Invoke(moveInput.x, moveInput.y);
        }


        void HandleLeftStick(Vector2 vector)
        {
            leftStickText.text = vector.ToString();
        }




    }

}
