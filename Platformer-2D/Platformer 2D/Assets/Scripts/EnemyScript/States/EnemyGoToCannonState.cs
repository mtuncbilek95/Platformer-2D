using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoToCannonState : EnemyState
{
    public EnemyGoToCannonState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, EnemyBaseData enemyData, string animBoolName) : base(enemyBase, stateMachine, enemyData, animBoolName)
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
        enemyData.canTakeDamage = true;
        enemyBase.CheckCannonSide();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        enemyBase.SetVelocityX(enemyData.maxSpeed * 1.5f * enemyBase.FacingDirection);

        if (Mathf.Abs(enemyBase.transform.position.x - CannonScript.matchPosition.x) <= 0.1f)
        {
            stateMachine.ChangeState(enemyBase.LightTheMatch);
        }

        else if (enemyBase.PlayerCheckFront() && enemyBase.AttackState.canAttack)
        {
            stateMachine.ChangeState(enemyBase.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
    
