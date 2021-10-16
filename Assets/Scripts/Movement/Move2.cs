using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Move2 : MonoBehaviour
{
    public float transitionSpeed = 2f;
    public float speed;
    public GameObject sisyphus;

    public void Movement()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        /*if (Input.GetButtonDown("Fire1"))
        {
            float x = Input.GetAxis("Horizontal") * 15.0f;
            float z = Input.GetAxis("Vertical") * 50.0f;

            sisyphus.transform.position = Vector3.Lerp(sisyphus.transform.position, new Vector3(0, 0, 1), Time.deltaTime * transitionSpeed);
            get transform.position
        }*/
    }
}
