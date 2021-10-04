using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    CharacterController controller;
    Vector3 moveVector;
    float verticalVelocity = 0.0f;
    public float gravity = 12.0f;
    private float animationDuration = 2.0f;

    float speed = 5.0f;
    public float xSpeed = 5.0f;
    float startTime;
    Vector3 position;
    Vector3 moveToPos;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    void Update()
    {
        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X - Left & Right Movement CONTROLLED HERE
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(position.x, transform.position.y, transform.position.z), xSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && (transform.position.x == 0.0f || transform.position.x == 1.0f || transform.position.x == 2.0f || transform.position.x == -1.0f || transform.position.x == -2.0f))
        {
            if (Input.mousePosition.x > (Screen.width / 2) && transform.position.x < 2.0f)
            {
                position.x = (transform.position.x + 1.0f);
            }

            else if (Input.mousePosition.x < (Screen.width / 2) && transform.position.x > -2.0f)
            {
                position.x = (transform.position.x - 1.0f);
            }
        }

        moveVector.y = verticalVelocity;
        moveVector.z = speed;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }
}
