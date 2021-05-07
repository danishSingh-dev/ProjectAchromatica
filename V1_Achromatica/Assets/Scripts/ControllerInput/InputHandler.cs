using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private float _horizontal = 0f;
    [SerializeField] private float _vertical = 0f;

    private Vector2 leftStickVector = Vector2.zero;
    private Vector2 rightStickVector = Vector2.zero;
    
    private bool crossButtonTap = false, crossButtonHold = false;
    private bool squareButtonTap = false, squareButtonHold = false;
    private bool triangleButtonTap = false, triangleButtonHold = false;
    private bool circleButtonTap = false, circleButtonHold = false;

    private bool leftDirPadTap = false, leftDirPadHold = false;
    private bool rightDirPadTap = false, rightDirPadHold = false;
    private bool upDirPadTap = false, upDirPadHold = false;
    private bool downDirPadTap = false, downDirPadHold = false;

    private bool leftBumperTap = false, leftBumperHold = false;
    private bool rightBumperTap = false, rightBumperHold = false;

    private bool leftTriggerTap = false, leftTriggerHold = false;
    private bool rightTriggerTap = false, rightTriggerHold = false;

    private bool leftStickTap = false, leftStickHold = false;
    private bool rightStickTap = false, rightStickHold = false;

    private bool optionsButtonTap = false;

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
