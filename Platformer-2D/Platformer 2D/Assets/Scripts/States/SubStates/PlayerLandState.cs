using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.RB.drag = playerData.dragValue;
    }

    public override void Exit()
    {
        base.Exit();
        player.RB.drag = 0f;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (xInput != 0)
        {
            stateMachine.ChangeState(player.MoveState);
        }
        else if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

}
