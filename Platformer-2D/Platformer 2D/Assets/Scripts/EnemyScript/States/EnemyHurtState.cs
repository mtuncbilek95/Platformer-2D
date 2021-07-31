using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyState
{
    private int hitForce = 100;

    public EnemyHurtState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, EnemyBaseData enemyData, string animBoolName) : base(enemyBase, stateMachine, enemyData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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
        isAnimationFinished = false;
        enemyData.canTakeDamage = false;
        enemyBase.SetVelocityX(0f);
        enemyBase.RB.AddForce(hitForce * Vector2.up);
        enemyBase.Health--;
        Debug.Log(enemyBase.Health);
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
            stateMachine.ChangeState(enemyBase.IdleState);
        }

        else if (enemyBase.Health <= 0)
        {
            stateMachine.ChangeState(enemyBase.DeadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
