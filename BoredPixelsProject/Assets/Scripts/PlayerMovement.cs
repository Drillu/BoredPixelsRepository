using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public Animator animator;
    public float speed = 40f;
    public int lifes;

    public int damage;
    public float cooldown;

    public GameObject gameOverMenu;

    public bool gameOver;
    public bool gameFinished;

    private bool readyToAttack;
    private bool died;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    void Start()
    {
        lifes = 9;
        gameOver = false;
        readyToAttack = true;
        died = false;

        animator = gameObject.GetComponent<Animator>();
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
            FindObjectOfType<AudioManager>().Play("playerJump");
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

        if(lifes<=0 || gameOver)
        {
            if(!died)
            {
                FindObjectOfType<AudioManager>().Play("playerDie");
                gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                animator.SetBool("isDied",true);
                gameOverMenu.SetActive(true);
                gameOver = true;
                died = true;
            }
            
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Enemy")
        {
            if(Input.GetButtonDown("Attack") && readyToAttack)
            {
                FindObjectOfType<AudioManager>().Play("playerAttack");
                animator.SetTrigger("isAttacking");
                other.gameObject.GetComponent<EnemyAi>().health -= damage;
                readyToAttack = false;
                StartCoroutine(Cooldown());
            }
        }
    }

    void FixedUpdate()
    {
        if(!gameOver && !gameFinished)
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
            jump = false;
        }
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        readyToAttack = true;
    }
}
