using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Transform posA;
    public Transform posB;
    public Transform platformObject;

    public int speed;

    private Vector3 nextPos;

    void Start()
    {
        nextPos = posA.localPosition;
    }

    void Update()
    {
        platformObject.localPosition = Vector2.MoveTowards(platformObject.position, nextPos, speed * Time.deltaTime);

        if(Vector3.Distance(platformObject.localPosition, nextPos) <= 0.1f)
        {
            Change();
        }
    }

    void Change()
    {
        nextPos = nextPos != posA.localPosition ? posA.localPosition : posB.localPosition;
    }
}
