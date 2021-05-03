using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private float _horizontal = 0f;
    [SerializeField] private float _vertical = 0f;

    #endregion

    #region Public Getters
    
    public float Horizontal { get { return _horizontal; } }
    public float Vertical { get { return _vertical; } }



    #endregion
    public void GetMovementVariables(float hor, float ver )
    {
        _horizontal = hor;
        _vertical = ver;
    }
}
