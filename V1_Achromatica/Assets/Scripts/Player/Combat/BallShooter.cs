using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputFunction;


namespace Combat
{
    public class BallShooter : MonoBehaviour
    {
        #region Variables

        [Header( "Components" )]
        [SerializeField] private InputReceiver _inputReceiver = null;
        [SerializeField] private Transform _shootPoint = null;
        [SerializeField] private GameObject _bulletPrefab = null;

        [Header( "Settings" )]
        [SerializeField] private int _bulletsFired = 1;
        [SerializeField] private float _bulletSpeed = 5f;
        [SerializeField] private float _bulletSpread = 2f;

        [Header( "Utility" )]
        [SerializeField] private bool _fire = false;

        #endregion


        #region MonoBehaviour Methods

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
            _inputReceiver.LightAttackPerformed += OnFire;
        }

        private void UnSubscribe( )
        {
            _inputReceiver.LightAttackPerformed -= OnFire;
        }

        #endregion


        public void OnFire( )
        {
            Debug.Log( "Fire once" );

        }
    }
}
