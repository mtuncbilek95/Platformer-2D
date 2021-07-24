using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    #region Movement Variables
    public Vector2 MovementRawInput { get; private set; }
    public int NormXInput { get; private set; }
    public int NormYInput { get; private set; }
    #endregion

    #region Jump Variables
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public float JumpInputTime { get; private set; }
    private float JumpHoldTime = 0.2f;
    #endregion

    #region Attack Variables
    public bool AttackInput { get; private set; }
    #endregion

    public bool DebugInput { get; private set; }
    
    #region Unity Callbacks
    private void Update()
    {
        CheckJumpTime();
    }
    #endregion

    #region InputAction Callbacks
    public void OnMovementInput(InputAction.CallbackContext context)
    {
        MovementRawInput = context.ReadValue<Vector2>();
        NormXInput = Mathf.RoundToInt(MovementRawInput.x);
        NormYInput = Mathf.RoundToInt(MovementRawInput.y);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputTime = Time.time;
            JumpInputStop = false;
            
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            AttackInput = true;
        }
        if (context.canceled)
        {
            AttackInput = false;
        }
    }

    public void OnDebugInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            DebugInput = true;
        }

        if (context.canceled)
        {
            DebugInput = false;
        }
    }
    #endregion

    #region Extra Functions 
    public void UseJumpInput() => JumpInput = false;

    public void CheckJumpTime() 
    {
        if(Time.time >= JumpInputTime + JumpHoldTime)
        {
            JumpInput = false;
        }
    }
    #endregion
}