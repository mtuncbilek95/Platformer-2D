using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    private float attackTime;
    public EnemyMoveState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, EnemyBaseData enemyData, string animBoolName) : base(enemyBase, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        enemyData.canTakeDamage = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        enemyBase.SetVelocityX(enemyData.maxSpeed * enemyBase.FacingDirection);

        if (!enemyBase.CheckIfGrounded())
        {
            stateMachine.ChangeState(enemyBase.IdleState);
        }

        else if (Time.time >= startTime + 0.2f)
        {
            enemyBase.AttackState.canAttack = true;

            if (enemyBase.PlayerCheckFront() && !enemyBase.PlayerCheckBack() && enemyBase.AttackState.canAttack)
            {
                stateMachine.ChangeState(enemyBase.AttackState);
            }

            else if (!enemyBase.PlayerCheckFront() && enemyBase.PlayerCheckBack() && enemyBase.AttackState.canAttack)
            {
                enemyBase.Flip();
                stateMachine.ChangeState(enemyBase.AttackState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
