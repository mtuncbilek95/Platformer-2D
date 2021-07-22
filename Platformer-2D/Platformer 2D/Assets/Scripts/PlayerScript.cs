using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    #region Components
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Needed Imports
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    [SerializeField] private PlayerData playerData;

    public Text stateNames;
    #endregion

    #region States
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }

    #endregion

    #region Variables
    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }

    public LayerMask checkGround;
    public int FacingDirection { get; private set; }

    [SerializeField] private Transform groundCheckObject;
    #endregion

    #region Unity Callback Functions
    public void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idleState");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "moveState");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jumpState");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "jumpState");
        LandState = new PlayerLandState(this, StateMachine, playerData, "landState");
        
    }
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        FacingDirection = 1;
    }
    private void Update()
    {
        stateNames.text = StateMachine.CurrentState.animBoolName;
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
    public void SetVelocityX(float velocity)
    {
        RB.AddForce(playerData.accelerateValue * Vector2.right * InputHandler.NormXInput, ForceMode2D.Force);

        if(Mathf.Abs(RB.velocity.x) > playerData.maxSpeed)
        {
            workspace.Set(Mathf.Sign(RB.velocity.x) * velocity, CurrentVelocity.y);
            RB.velocity = workspace;
            CurrentVelocity = workspace;
        }

    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public bool IsGrounded()
    {
        return Physics2D.Raycast(groundCheckObject.position * playerData.groundLayerLength, Vector2.down, playerData.groundLayerLength, checkGround);
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if (xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundCheckObject.position, groundCheckObject.position + Vector3.down * playerData.groundLayerLength);
    }

    private void AnimationTriggerFunction() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTriggerFunction() => StateMachine.CurrentState.AnimationFinishTrigger();
}
