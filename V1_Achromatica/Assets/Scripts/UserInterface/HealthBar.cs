using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UIFunction
{
    public class HealthBar : MonoBehaviour, UIBarInterface
    {
        public Image _representation = null;
        public float _currentValue = 0f;
        [Range(0, 1)]
        public float _valueToChangeTo = 0.5f;

        public bool _changeValue = false;

        private void Update( )
        {
            CheckValue( );

            if ( _changeValue )
            {
                ChangeValue( _valueToChangeTo );
                _changeValue = false;
            }
        }






        public void ChangeValue( float value )
        {
            if(value == _currentValue )
            { return; }

            _representation.fillAmount = value;

        }

        public void CheckValue( )
        {
            _currentValue = _representation.fillAmount;
        }
    }
}
