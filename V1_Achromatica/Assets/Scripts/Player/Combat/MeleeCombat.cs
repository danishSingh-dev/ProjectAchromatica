using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputFunction;

namespace Combat
{
    public class MeleeCombat : MonoBehaviour
    {
        #region Variables

        [Header( "Components" )]
        [SerializeField] private InputReceiver _inputReceiver = null;

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
            // Light Attack Subscription
            _inputReceiver.LightAttackPerformed += OnLightAttack;
            _inputReceiver.LightAttackHeldStarted += OnChargedLightAttackStarted;
            _inputReceiver.LightAttackHeldPerformed += OnChargedLightAttack;


            // Heavy Attack Subscription
            _inputReceiver.HeavyAttackPerformed += OnHeavyAttack;
            _inputReceiver.HeavyAttackHeldStarted += OnChargedHeavyAttackStarted;
            _inputReceiver.HeavyAttackHeldPerformed += OnChargedHeavyAttack;


            // Ranged Attack Subscription
            _inputReceiver.RangedAttackPerformed += OnRangedAttack;
            _inputReceiver.RangedAttackHeldStarted += OnChargedRangedAttackStarted;
            _inputReceiver.RangedAttackHeldPerformed += OnChargedRangedAttack;
            _inputReceiver.RangedAttackHeldCanceled += OnChargedRangedAttackCanceled;
        }

        private void UnSubscribe( )
        {
            // Light Attack UnSubscription
            _inputReceiver.LightAttackPerformed -= OnLightAttack;
            _inputReceiver.LightAttackHeldStarted -= OnChargedLightAttackStarted;
            _inputReceiver.LightAttackHeldPerformed -= OnChargedLightAttack;


            // Heavy Attack UnSubscription
            _inputReceiver.HeavyAttackPerformed -= OnHeavyAttack;
            _inputReceiver.HeavyAttackHeldStarted -= OnChargedHeavyAttackStarted;
            _inputReceiver.HeavyAttackHeldPerformed -= OnChargedHeavyAttack;


            // Ranged Attack UnSubscription
            _inputReceiver.RangedAttackPerformed -= OnRangedAttack;
            _inputReceiver.RangedAttackHeldStarted -= OnChargedRangedAttackStarted;
            _inputReceiver.RangedAttackHeldPerformed -= OnChargedRangedAttack;
            _inputReceiver.RangedAttackHeldCanceled -= OnChargedRangedAttackCanceled;
        }

        #endregion


        #region Light Attack Functionality

        private void OnLightAttack( )
        {

        }

        private void OnChargedLightAttack( )
        {

        }
        
        private void OnChargedLightAttackStarted( )
        {

        }

        #endregion


        #region Heavy Attack Functionality

        private void OnHeavyAttack( )
        {

        }

        private void OnChargedHeavyAttack( )
        {

        }
        
        private void OnChargedHeavyAttackStarted( )
        {

        }


        #endregion


        #region Ranged Attack Functionality

        private void OnRangedAttack( )
        {

        }

        private void OnChargedRangedAttack( )
        {

        }

        private void OnChargedRangedAttackStarted( float value )
        {

        }

        private void OnChargedRangedAttackCanceled( )
        {

        }


        #endregion


    }
}
