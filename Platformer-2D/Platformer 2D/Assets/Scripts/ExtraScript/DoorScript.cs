using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator Animator { get; private set; }

    public enum State
    {
        Idle,
        Open,
        Close
    }

    private State state;
    private void Start()
    {
        Animator = GetComponent<Animator>();
        state = State.Idle;
    }

    public void Update()
    {
        switch (state)
        {
            case State.Idle:
                Animator.SetTrigger("idleState");
                break;
            case State.Open:
                Animator.SetTrigger("openState");
                break;
            case State.Close:
                Animator.SetTrigger("closeState");
                break;
        }
    }


}
