using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonScript : MonoBehaviour
{
    [SerializeField] GameObject cannonBall;
    [SerializeField] private Transform matchTransform;
    [SerializeField] private Transform spawnTransform;

    [SerializeField] private Transform playerCheckBox;
    [SerializeField] private Vector2 size;
    [SerializeField] private LayerMask player;

    [SerializeField] private UnityEvent enemyEvent;

    public Animator Animator { get; private set; }

    public static Vector2 cannonPosition;
    public static Vector2 matchPosition;
    public static Vector2 spawnPosition;

    public static int FacingDirection;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        cannonPosition = this.transform.position;

        matchPosition = matchTransform.position;
        spawnPosition = spawnTransform.position;

        if(transform.rotation.y != 0)
        {
            FacingDirection = 1;
        }
        else
        {
            FacingDirection = -1;
        }
    }

    private void Update()
    {
        PlayerCheck();
        if (PlayerCheck())
        {
            enemyEvent?.Invoke();
        }
    }
    public void FireCannon()
    {
        Instantiate(cannonBall, spawnTransform.position, Quaternion.identity, null);
        Animator.SetTrigger("fireCannon");
    }

    public bool PlayerCheck()
    {
        return Physics2D.OverlapBox(playerCheckBox.position, size, 0, player);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerCheckBox.position, size);
        Gizmos.DrawWireSphere(matchTransform.position, 0.2f);
    }
}
