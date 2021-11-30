using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    CharacterController cc;
    public float vSpeed;
    public float hSpeed;
    public float rSpeed;
    public float gravity;
    public Vector3 move;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 aux;
        if (cc.isGrounded)
        {
            move = new Vector3(Input.GetAxis("Vertical"), 0f, /*Input.GetAxis("Horizontal") * -1f*/0f);
            move = transform.TransformDirection(move);

            aux = new Vector3(0f,Input.GetAxis("Horizontal") * rSpeed, 0f) * Time.deltaTime;
            transform.eulerAngles += aux;

            move *= hSpeed;

            if (Input.GetButton("Jump")){
                move.y = vSpeed;
            }
        }

        move.y -= gravity * Time.deltaTime;

        cc.Move(move * Time.deltaTime);
    }
}
