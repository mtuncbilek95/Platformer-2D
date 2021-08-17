using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject[] hearts;
    public PlayerScript player;

    private void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < player.Health)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                StartCoroutine(HeartDestroyFunction(i));
            }

        }
    }
    IEnumerator HeartDestroyFunction(int i)
    {
        Animator animator = hearts[i].GetComponent<Animator>();
        animator.SetTrigger("Hit");
        yield return new WaitForSeconds(0.2f);
        hearts[i].SetActive(false);
    }
}
