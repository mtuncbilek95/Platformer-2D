using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public EnemyStateMachine StateMachine { get; private set; }

    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }
    public EnemyHurtState HurtState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState (this, StateMachine, "idleState");
        MoveState = new EnemyMoveState(this, StateMachine, "moveState");
        HurtState = new EnemyHurtState(this, StateMachine, "hurtState");
        AttackState = new EnemyAttackState(this, StateMachine, "attackState");
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
