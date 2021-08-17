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
    private bool isCoroutineExecuting;

    void Start()
    {
        nextPos = posA.localPosition;
    }

    void Update()
    {
        platformObject.localPosition = Vector2.MoveTowards(platformObject.position, nextPos, speed * Time.deltaTime);

        if(Vector3.Distance(platformObject.localPosition, nextPos) == 0)
        {
            StartCoroutine(ExecuteAfterTime(0.5f));
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        Change();
        isCoroutineExecuting = false;
    }
    void Change()
    {
        nextPos = nextPos != posA.localPosition ? posA.localPosition : posB.localPosition;
    }
}
