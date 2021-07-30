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
        [SerializeField] private Animator _animator = null;

        [Header( "Settings" )]
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _moveSmoothing = 2f;
        [SerializeField] private float _rotationSmoothing = 5f;

        [Header( "Utility" )]
        [SerializeField] private float _horizontal = 0f;
        [SerializeField] private float _vertical = 0f;
        [SerializeField] private Vector3 _moveDirection = Vector3.zero;
        [SerializeField] private Quaternion _rotationToCamera = Quaternion.Euler( Vector3.zero );
        [SerializeField] private Quaternion _rotationToMoveDirection = Quaternion.Euler( Vector3.zero );

        [Header( "Temporary Weapon" )]
        [SerializeField] private bool _sheathed = true;
        [SerializeField] private bool _drawWeapon = false;
        [SerializeField] private bool _katanaEquipped = false;
        [SerializeField] private Transform _Greatsword = null;
        [SerializeField] private Transform _Katana = null;
        [SerializeField] private Transform _weapon = null;
        [SerializeField] private Transform _sheathPosition = null;
        [SerializeField] private Transform _drawnPosition = null;

        #endregion



        #region MonoBehaviour Methods

        private void Start( )
        {
            _weapon = _Greatsword;
            _Katana.gameObject.SetActive( false );
        }

        private void Update( )
        {
            //GetMovementInput( );

            CalculateMoveDirection( );

            UpdateWeaponPosition( );
            UpdateAnimator( );

            
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
            _inputReceiver.LightAttackPerformed += _inputReceiver_LightAttackPerformed;
            _inputReceiver.DirDownPerformed += _inputReceiver_DirDownPerformed;
            _inputReceiver.DirDownHeldPerformed += _inputReceiver_DirDownHeldPerformed;
        }

        

        private void UnSubscribe( )
        {
            _inputReceiver.Movement -= OnMove;
            _inputReceiver.LightAttackPerformed -= _inputReceiver_LightAttackPerformed;
            _inputReceiver.DirDownPerformed += _inputReceiver_DirDownPerformed;

        }

        #endregion





        #region Update Functions


        private void UpdateWeaponPosition( )
        {
            if ( !_drawWeapon )
            {
                _weapon.position = _sheathPosition.position;
                _weapon.rotation = _sheathPosition.rotation;

            }
            else
            {
                _weapon.position = _drawnPosition.position;
                _weapon.rotation = _drawnPosition.rotation;
            }
        }

        private void UpdateActiveWeapon( )
        {
            if ( _katanaEquipped )
            {
                _Greatsword.gameObject.SetActive( false );
                _Katana.gameObject.SetActive( true );
                _weapon = _Katana;
            }
            else
            {
                _Katana.gameObject.SetActive( false );
                _Greatsword.gameObject.SetActive( true );
                _weapon = _Greatsword;
            }
        }

        private void UpdateAnimator( )
        {
            _animator.SetFloat( "Horizontal" , _horizontal );
            _animator.SetFloat( "Vertical" , _vertical );

            if ( CheckIfWalking() )
            {
                _animator.SetBool( "isWalking" , true );
            }
            else
            {
                _animator.SetBool( "isWalking" , false );
            }

            if ( _sheathed )
            {
                _animator.SetBool( "isSheathed" , true );
            }
            else
            {
                _animator.SetBool( "isSheathed" , false );
            }
        }


        #endregion


        #region Animation Events

        public void WeaponDrawn( )
        {
            _drawWeapon = true;
        }

        public void WeaponSheathed( )
        {
            _drawWeapon = false;
        }

        #endregion



        #region Input Functions

        private void OnMove( Vector2 vector )
        {
            _horizontal = vector.x;
            _vertical = vector.y;
        }

        private void _inputReceiver_LightAttackPerformed( )
        {
            
        }

        private void _inputReceiver_DirDownPerformed( )
        {
            Debug.Log( "DirDown Pressed" );
            _katanaEquipped = !_katanaEquipped;
            UpdateActiveWeapon( );
            
            
            
        }

        private void _inputReceiver_DirDownHeldPerformed( )
        {
            Debug.Log( "DirDown Held" );
           
            if ( !CheckIfWalking( ) )
            {
                _sheathed = !_sheathed;
            }
        }


        #endregion 



        #region Utility Methods

        private bool CheckIfWalking( )
        {
            if( _horizontal != 0f || _vertical != 0f )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void CalculateMoveDirection( )
        {
            _moveDirection = ( Vector3.forward * _vertical ) + ( Vector3.right * _horizontal );

            Vector3 projectedCameraForward = Vector3.ProjectOnPlane( Camera.main.transform.forward , Vector3.up );

            _rotationToCamera = Quaternion.LookRotation( projectedCameraForward , Vector3.up );

            _moveDirection = _rotationToCamera * _moveDirection;

            //_rotationToMoveDirection = Quaternion.LookRotation( _moveDirection , Vector3.up );
        }

        private void MovePlayerWithTransform( )
        {
            Vector3 newPosition = transform.position + ( _moveDirection * _moveSpeed * Time.fixedDeltaTime );

            float difference = Vector3.Distance( transform.position , newPosition );



            if(difference > 0.01f)
            {
                transform.rotation = Quaternion.Slerp( transform.rotation , _rotationToCamera , _rotationSmoothing * Time.fixedDeltaTime );
            }

            //transform.rotation = Quaternion.Slerp( transform.rotation , _rotationToMoveDirection , _rotationSmoothing * Time.fixedDeltaTime );
            transform.position = Vector3.Lerp( transform.position , newPosition , _moveSmoothing);
        }

        // Unused Functions //

        //private void GetMovementInput( )
        //{
        //    Vector2 vector = Vector2.zero;
        //    vector = _inputHandler.LeftStickVector;

        //    _horizontal = vector.x;
        //    _vertical = vector.y;
        //}

        #endregion
    }
}
