using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    public float speed = 40f;

    float horizontalMove = 0f;
    bool walking = false;
    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            walking = true;
            animator.SetBool("isWalking",true);
        }
        else
        {
            walking = false;
            animator.SetBool("isWalking",false);
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
