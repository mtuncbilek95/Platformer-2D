using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CannonBallScript : MonoBehaviour
{
    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RB.velocity = new Vector2(10 * CannonScript.FacingDirection, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            var script = collision.GetComponent<PlayerScript>();
            script.DamageCharacter();
            Destroy(GameObject.FindGameObjectWithTag("Cannon Ball"));
        }

        else
        {
            Destroy(GameObject.FindGameObjectWithTag("Cannon Ball"));
        }
    }
}
