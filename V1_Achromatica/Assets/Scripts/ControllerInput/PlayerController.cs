using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Danish.Input
{



    public class PlayerController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Animator _anim = null;
        [SerializeField] private InputHandler _inputHandler = null;
        [SerializeField] private float moveSpeed = 3f;

        private float _horizontal = 0f;
        private float _vertical = 0f;

        #endregion


        #region MonoBehaviours


        private void Update( )
        {
            if(_inputHandler != null )
            {
                _horizontal = _inputHandler.Horizontal;
                _vertical = _inputHandler.Vertical;
            }
        }


        private void FixedUpdate()
        {
            MoveFunctionality();
        }

        #endregion


        #region Functionality Methods

        private void MoveFunctionality()
        {
            //Vector3 moveDirection = Vector3.forward * _vertical + Vector3.right * _horizontal;

            //Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
            //Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);

            //moveDirection = rotationToCamera * moveDirection;

            //float difference = Vector3.Distance(transform.position ,((transform.position) + (moveDirection * moveSpeed * Time.fixedDeltaTime)));

            //transform.position += moveDirection * moveSpeed * Time.fixedDeltaTime;
            
            //if(difference > 0.01f)
            //    transform.rotation = rotationToCamera;

            UpdateAnimatorVariables( );
        }

        private void UpdateAnimatorVariables()
        {
            if ( _anim == null )
                return;

            _anim.SetFloat( "Horizontal" , _horizontal );
            _anim.SetFloat( "Vertical" , _vertical );
        }

        #endregion

        //public void MovePlayer(float horizontal, float vertical)
        //{
        //    _horizontal = horizontal;
        //    _vertical = vertical;
        //    Debug.Log(horizontal + " " + vertical);
        //}
    }
}