using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] Animator animator;
    Vector3 pMove;
    public bool isGrounded;
    public bool grounded;
    public bool dive;
    float jSpeed;

    private void Start()
    {
        pMove = new Vector3();
        grounded = true;
        dive = false;

        animator.SetBool("param_grounded", true);
        animator.SetBool("param_dive", false);
    }
    private void Update()
    {
        isGrounded = GetComponent<Moviment>().GetGrounded();
        pMove = GetComponent<Moviment>().move;
        jSpeed = GetComponent<Moviment>().vSpeed;

        //jumping

        //Jumping();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dive = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            dive = false;
        }
        animator.SetBool("param_diving", dive);

        //walking
        if (Input.GetButton("Vertical"))
        {
            WalkingAnim(true);
        }
        else
        {
            WalkingAnim(false);
        }
    }

    void WalkingAnim(bool v)
    {
        animator.SetBool("param_move", v);
    }

    void Jumping()
    {
        if(pMove.y > 1)
        {
            animator.SetBool("param_grounded", false);
            animator.SetBool("param_diving", true);

            if(pMove.y < 1)
            {
                animator.SetBool("param_grounded", true);
            }
        }
    }
}
