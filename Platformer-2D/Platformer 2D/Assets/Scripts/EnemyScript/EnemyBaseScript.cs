using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBaseScript : MonoBehaviour, IDamageable
{
    #region Components
    public EnemyBaseData enemyData;
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public bool EnemyisDead { get; set; }
    #endregion

    #region Enemy State Files
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyIdleState IdleState { get; private set; }
    public EnemyMoveState MoveState { get; private set; }
    public EnemyHurtState HurtState { get; private set; }
    public EnemyAttackState AttackState { get; private set; }
    public EnemyDeadState DeadState { get; private set; }
    #endregion

    #region Variables

    [Header("Attachable Objects")]
    public Transform ledgeCheckObject;
    public Transform wallCheckObject;
    public Transform playerCheckObject;
    public Transform weaponCollider;
    
    private Vector2 currentVelocity;
    
    [SerializeField] private Vector3 playerCheckOffset;

    public float FacingDirection { get; private set; }

    [Header("Layers")]
    [SerializeField] private LayerMask wallCheck;
    [SerializeField] private LayerMask groundCheck;
    [SerializeField] private LayerMask playerCheck;
    
    [Header("Unity Events")]
    [field: SerializeField]
    private UnityEvent OnPlayerHit;
    public int Health { get; set; } 
    #endregion

    #region Unity Callback Functions
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        IdleState = new EnemyIdleState(this, StateMachine, enemyData, "idleState");
        MoveState = new EnemyMoveState(this, StateMachine, enemyData, "moveState");
        HurtState = new EnemyHurtState(this, StateMachine, enemyData, "hurtState");
        AttackState = new EnemyAttackState(this, StateMachine, enemyData, "attackState");
        DeadState = new EnemyDeadState(this, StateMachine, enemyData, "deadState");
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        StateMachine.Initialize(IdleState);
        FacingDirection = -1;
        AttackState.canAttack = true;
        Health = enemyData.health;
        EnemyisDead = false;
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions
    public bool CheckIfGrounded()
    {
        return Physics2D.Raycast(ledgeCheckObject.position, Vector2.down, enemyData.ledgeCheckLength, groundCheck);
    }

    public bool PlayerCheckFront()
    {
        return Physics2D.OverlapCircle(playerCheckObject.position + playerCheckOffset, enemyData.playerCheckRadius, playerCheck);
    }
    public bool PlayerCheckBack()
    {
        return Physics2D.OverlapCircle(playerCheckObject.position - playerCheckOffset, enemyData.playerCheckRadius, playerCheck);
    }

    public bool HitCheckPlayer()
    {
        return Physics2D.OverlapCircle(weaponCollider.position, enemyData.weaponRadius, playerCheck);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(ledgeCheckObject.position, ledgeCheckObject.position + (Vector3)(Vector2.down * enemyData.ledgeCheckLength));
        Gizmos.DrawWireSphere(playerCheckObject.position + playerCheckOffset, enemyData.playerCheckRadius);
        Gizmos.DrawWireSphere(playerCheckObject.position - playerCheckOffset, enemyData.playerCheckRadius);
        Gizmos.DrawWireSphere(weaponCollider.position, enemyData.weaponRadius);

    }

    #endregion

    public virtual void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
        playerCheckOffset *= -1;
    }

    public void SetVelocityX(float velocity)
    {
        currentVelocity.Set(velocity, currentVelocity.y);
        RB.velocity = currentVelocity;
    }

    #region Trigger Functions
    private void AnimationTriggerFunction() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTriggerFunction() => StateMachine.CurrentState.AnimationFinishTrigger();
    public void HitCheckTriggerFunction()
    {
        if (HitCheckPlayer())
        {
            OnPlayerHit?.Invoke();
        }
    }
    public void DamageEnemy()
    {
        if (enemyData.canTakeDamage)
        {
            StateMachine.ChangeState(HurtState);
        }
    }
    #endregion
}
