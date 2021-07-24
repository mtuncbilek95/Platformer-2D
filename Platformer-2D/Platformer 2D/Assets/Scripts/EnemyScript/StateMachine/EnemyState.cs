using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    public EnemyBaseScript enemyBase;
    public EnemyStateMachine stateMachine;

    public string animBoolName;
    
    public float startTime;

    public bool isAnimationFinished;

    public EnemyState(EnemyBaseScript enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemyBase = enemyBase;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        enemyBase.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
    }

    public virtual void Exit()
    {
        enemyBase.Animator.SetBool(animBoolName, false);
    }

    public virtual void DoChecks()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
