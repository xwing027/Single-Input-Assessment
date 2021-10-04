using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Sisyphus Game/Character Controller")]
[RequireComponent(typeof(CharacterController))]

public class CharCon : MonoBehaviour
{
    [SerializeField]
    float speed;
    

    Vector3 movement;

    CharacterController charCon;

    void Start()
    {
        charCon = GetComponent<CharacterController>();
    }

    void Update()
    {
        movement.x = 0;

        //movement += transform.forward * Input.GetAxisRaw("Vertical") * speed;
        movement += transform.right * Input.GetAxisRaw("Horizontal") * speed;

        charCon.Move(movement * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(0, 0, 1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0,0,1 * Time.deltaTime);
        }
    }
}
