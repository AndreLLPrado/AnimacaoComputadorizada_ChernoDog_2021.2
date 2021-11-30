using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Update()
    {
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
}
