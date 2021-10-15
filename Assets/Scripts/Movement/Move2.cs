using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float transitionSpeed = 2f;
    public float speed;

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            /*float x = Input.GetAxis("Horizontal") * 15.0f;
            float z = Input.GetAxis("Vertical") * 50.0f;

            CharacterController sisyphus = GetComponent<CharacterController>();
            sisyphus.transform.position = Vector3.Lerp(sisyphus.transform.position, new Vector3(0, 0, 1), Time.deltaTime * transitionSpeed);*/
        }
        

        
    }
}
