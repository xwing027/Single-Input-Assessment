using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 1.0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            StartCoroutine(MovePlayer(Vector3.forward));
        }
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0.0f;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime > timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, elapsedTime);
            elapsedTime += Time.deltaTime / timeToMove;
            yield return new WaitForEndOfFrame();
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
