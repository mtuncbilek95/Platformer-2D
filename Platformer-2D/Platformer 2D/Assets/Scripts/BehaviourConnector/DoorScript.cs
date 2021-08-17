using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorScript : MonoBehaviour
{
    private Animator animator;

    private bool canBeOpened;
    public static bool canBeEntered;

    private void Start()
    {
        animator = GetComponent<Animator>();
        canBeOpened = false;

    }

    public void UnlockTheDoor()
    {
        canBeOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canBeOpened)
        {
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            canBeEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Close", true);
            animator.SetBool("Open", false);
            canBeEntered = false;
        }
    }
}

