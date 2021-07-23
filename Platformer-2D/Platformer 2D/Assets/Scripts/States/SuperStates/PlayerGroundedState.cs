using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected bool isGrounded;
    protected bool jumpInput;
    protected bool attackInput;
    protected int xInput;
    
    public PlayerGroundedState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.IsGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetJump();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        xInput = player.InputHandler.NormXInput;
        jumpInput = player.InputHandler.JumpInput;
        attackInput = player.InputHandler.AttackInput;
        
        if (attackInput && player.AttackState.CanAttack())
        {
            stateMachine.ChangeState(player.AttackState);
        }
        else if (player.JumpState.CanJump() && jumpInput)
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        
    }
}
