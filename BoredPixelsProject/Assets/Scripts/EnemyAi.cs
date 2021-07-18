using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public float attackRange;
    public int damage;
    public float cooldown;
    public float attackTime;

    public Vector2 targetRange;
    public float patrolRange;

    public float speed;

    public PlayerController controller;
    public GameObject player;

    private Vector3 startingPosition;
    private int direction = 1;

    private bool patrolState;
    private bool chaseState;

    private bool readyToAttack; 

    void Start()
    {
        startingPosition = transform.position;
        patrolState = true;
        readyToAttack = true;
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.x - player.transform.position.x) <= targetRange.x && Mathf.Abs(transform.position.x - player.transform.position.x) <= targetRange.x)
        {
            patrolState = false;
            chaseState = true;
        }
        else
        {
            patrolState = true;
            chaseState = false;
        }
    }

    void FixedUpdate()
    {
        if(patrolState)
        {
            controller.Move(speed * direction * Time.fixedDeltaTime, false, false);
            if((transform.position.x - startingPosition.x) * direction >= patrolRange)
            {
                direction *= -1;
            }
        }

        if(chaseState)
        {
            if(player.transform.position.x - transform.position.x > 0)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            if(Vector2.Distance(player.transform.position, transform.position) < attackRange && readyToAttack)
            {
                StartCoroutine(Attack());
            }

            controller.Move(speed * direction * Time.fixedDeltaTime, false, false);

        }
        
    }

    IEnumerator Attack()
    {
        readyToAttack = false;
        yield return new WaitForSeconds(attackTime);
        if(Vector2.Distance(player.transform.position, transform.position) < attackRange)
        {
            player.GetComponent<PlayerMovement>().lives -= damage;
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        readyToAttack = true;
    }
}
