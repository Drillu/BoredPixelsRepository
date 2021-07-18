using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    public float speed = 40f;
    public int lives;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        lives = 9;
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if(Input.GetAxisRaw("Horizontal")!=0)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetTrigger("isJumping");
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("isCrouching",true);
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("isCrouching",false);
            animator.ResetTrigger("isJumping");
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
