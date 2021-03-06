using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class EnemyAi : MonoBehaviour
{
    public string type;
    public float attackRange;
    public int damage;
    public float cooldown;
    public float attackTime;
    public float health;

    public Vector2 targetRange;
    public float patrolRange;

    public float speed;
    public float runSpeed;

    public PlayerController controller;
    private GameObject player;
    public Slider slider;
    public Vector3 healthBarOffset;

    public bool isBoss = false;
    [SerializeField] public UnityEvent Access;

    private Vector3 startingPosition;
    private int direction = 1;

    private bool patrolState;
    private bool chaseState;

    private bool readyToAttack;
    public bool isDied;
    private bool givedLife;

    private Animator animator;

    void Start()
    {
        startingPosition = transform.position;
        if(gameObject.GetComponent<Animator>() != null) animator = gameObject.GetComponent<Animator>();
        patrolState = true;
        readyToAttack = true;
        player =  GameObject.Find("Player");
        givedLife = false;

        slider.maxValue = health;
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

        if(health<=0 || isDied)
        {   

            if(player.GetComponent<PlayerMovement>().lifes < 9 && !givedLife)
            {
                player.GetComponent<PlayerMovement>().lifes += 1;
                givedLife = true;
                FindObjectOfType<AudioManager>().Play(type + "Die");
            }

            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if(slider!=null) Destroy(slider.gameObject);
            StartCoroutine(Die());
            if(Access!=null) Access.Invoke();
        }

        if(slider!=null)
        {
            slider.value = health;
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + healthBarOffset);
        }
        
    }

    void FixedUpdate()
    {
        if(patrolState && !player.GetComponent<PlayerMovement>().gameOver && !isDied)
        {
            controller.Move(speed * direction * Time.fixedDeltaTime, false, false);
            if((transform.position.x - startingPosition.x) * direction >= patrolRange)
            {
                direction *= -1;
            }
        }

        if(chaseState && !player.GetComponent<PlayerMovement>().gameOver && !isDied)
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

            controller.Move(runSpeed * direction * Time.fixedDeltaTime, false, false);

        }
        
    }

    IEnumerator Attack()
    {
        FindObjectOfType<AudioManager>().Play(type + "Attack");
        readyToAttack = false;
        if(animator != null) animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(attackTime);
        if(Vector2.Distance(player.transform.position, transform.position) < attackRange)
        {
            player.GetComponent<PlayerMovement>().lifes -= damage;
            FindObjectOfType<AudioManager>().Play("playerHurt");
            if(animator != null) animator.SetTrigger("isAttacking");
        }
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        readyToAttack = true;
    }

    IEnumerator Die()
    {
        if(animator != null) animator.SetBool("isDied", true);
        isDied = true;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
