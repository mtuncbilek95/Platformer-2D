using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public PlayerScript player;
    public PlayerStateMachine stateMachine;
    public PlayerData playerData;

    public bool isAnimationFinished;

    public float startTime;

    public string animBoolName;

    protected PlayerState(PlayerScript player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoChecks();
        player.Animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = false;
    }

    public virtual void Exit()
    {
        player.Animator.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger() { }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
