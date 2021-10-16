using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WPMovement : MonoBehaviour
{
    public GameObject[] goal;
    public GameObject currentGoal;
    int goalIndex = 0;
    public GameObject sisyphus;

    public void Start()
    {
        //currentGoal = goal[goalIndex];
        currentGoal.transform.position = transform.position;
        currentGoal.transform.rotation = transform.rotation;
    }


    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("You have moved");

            //sisyphus.transform.position = currentGoal.transform.position;
            currentGoal.transform.Translate(Vector3.right);
        }
        transform.position = Vector3.Lerp(transform.position,currentGoal.transform.position,.1f);

    }

    public void FindMove(GameObject goal)
    {
        //find the goal
        float distance = Vector3.Distance(transform.position, goal.transform.position);

        if (distance < 0.01f)
        {
            NextGoal();
        }
    }

    public void NextGoal()
    {
        goalIndex++;

        if (goalIndex>goal.Length - 1)
        {
            goalIndex = 0;
        }

        currentGoal = goal[goalIndex];
    }
}