using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitState : PlayerAbilityState
{
   
    public PlayerHitState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAbilityDone = true;
    }

    public override void AnimationTrigger()
    {
        base.AnimationTrigger();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
        player.SetVelocityY(playerData.hitForceY);

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(0f);

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
