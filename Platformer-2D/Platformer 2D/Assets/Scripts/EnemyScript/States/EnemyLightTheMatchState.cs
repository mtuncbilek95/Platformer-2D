using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLightTheMatchState : EnemyState
{
    public EnemyLightTheMatchState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, EnemyBaseData enemyData, string animBoolName) : base(enemyBase, stateMachine, enemyData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        isAnimationFinished = true;
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
        enemyData.canTakeDamage = true;
        if (enemyBase.FacingDirection != CannonScript.FacingDirection)
        {
            enemyBase.Flip();
        }

        enemyBase.SetVelocityX(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(enemyBase.MatchOnState);
        }

        else if (isAnimationFinished && enemyBase.PlayerCheckFront() && enemyBase.AttackState.canAttack)
        {
            stateMachine.ChangeState(enemyBase.AttackState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
