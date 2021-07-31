using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float idleTime;
    private float attackTime;

    public EnemyIdleState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, EnemyBaseData enemyData, string animBoolName) : base(enemyBase, stateMachine, enemyData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        SetIdleTime();
        enemyBase.SetVelocityX(0f);
        enemyData.canTakeDamage = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            if (!enemyBase.CheckIfGrounded())
            {
                enemyBase.Flip();
            }

            else if (enemyBase.CheckIfGrounded())
            {
                stateMachine.ChangeState(enemyBase.MoveState);
            }
        }
        else if (Time.time >= startTime + attackTime)
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

    public void SetIdleTime()
    {
        idleTime = Random.Range(0.5f, 2f);
        attackTime = Random.Range(0.5f, 1f);
    }
}
