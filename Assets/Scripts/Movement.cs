using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    public GameObject[] goal;
    public GameObject currentGoal;
    public GameObject sisyphus;

    public GameObject start;
   // public Rigidbody endRB;
    private Vector3 startPosition;

    BeatManager beatManager;
    BPMManager bpmManager;
    #endregion
    
    public void Start()
    {
        currentGoal.transform.position = transform.position; //this and the line below find the goal for sisyphus to move to
        currentGoal.transform.rotation = transform.rotation;

        startPosition = start.transform.position;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentGoal.transform.Translate(Vector3.forward);
            Debug.Log("You have moved");
        }
        transform.position = Vector3.Lerp(transform.position,currentGoal.transform.position,.1f);

        //endRB.isKinematic = false;
        //endRB.detectCollisions = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End")) //when you the end zone
        {
            sisyphus.transform.position = startPosition; //reset sisyphus' position to the start
            currentGoal.transform.position = startPosition; //reset the goal pos to the start as well
        }
        //if (other.gameObject.CompareTag("Zone1"))
        //{
            //bpmManager.OneTwentyBeat();
        //}
    }
}
