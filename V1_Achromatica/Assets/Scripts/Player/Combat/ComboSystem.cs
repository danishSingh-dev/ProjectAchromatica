using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using InputFunction;

namespace Combat
{
    public class ComboSystem : MonoBehaviour
    {
        // Keep track of when the Player uses Light, Heavy and Ranged Attacks.

        #region Variables

        [Header( "Components" )]
        [SerializeField] private InputReceiver _inputReceiver = null;
        private System.Diagnostics.Stopwatch _stopwatch = null;
        
        [Header("Settings")]
        [SerializeField] private int _currentComboCount = 0;


        #endregion

        #region MonoBehaviour Methods

        private void Start( )
        {
            _stopwatch = new System.Diagnostics.Stopwatch( );
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
            _inputReceiver.LightAttackHeldPerformed += ComboCheck;
            _inputReceiver.LightAttackPerformed += ComboCheck;

            _inputReceiver.HeavyAttackHeldPerformed += ComboCheck;
            _inputReceiver.HeavyAttackPerformed += ComboCheck;

            _inputReceiver.RangedAttackHeldPerformed += ComboCheck;
            _inputReceiver.RangedAttackPerformed += ComboCheck;
        }

        private void UnSubscribe( )
        {
            _inputReceiver.LightAttackHeldPerformed -= ComboCheck;
            _inputReceiver.LightAttackPerformed -= ComboCheck;

            _inputReceiver.HeavyAttackHeldPerformed -= ComboCheck;
            _inputReceiver.HeavyAttackPerformed -= ComboCheck;

            _inputReceiver.RangedAttackHeldPerformed -= ComboCheck;
            _inputReceiver.RangedAttackPerformed -= ComboCheck;
        }

        #endregion


        #region Functionality

        private void ComboCheck( )
        {
            if ( !_stopwatch.IsRunning )
                _stopwatch.Start();

            float timeLeft = 0f;
            timeLeft = (float) _stopwatch.Elapsed.TotalSeconds;
        }


        #endregion
    }
}
