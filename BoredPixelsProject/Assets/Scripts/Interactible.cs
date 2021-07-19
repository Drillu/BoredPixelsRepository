using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class Interactible : MonoBehaviour
{
    public GameObject message;
    public float transTime = 1f;

    public Vector3 messageOffset;
    public UnityEvent Interact;

    public Animator animator;

    
    void Start()
    {
       // animator = GetComponent<Animator>();
    }

    void Update()
    {
        message.transform.position = Camera.main.WorldToScreenPoint(transform.position + messageOffset);   
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            message.SetActive(true);
            if(Input.GetButtonDown("Interact"))
            {
                Interact.Invoke();
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            message.SetActive(false);
        }
    }

    public void SleepInBox()
    {
        StartCoroutine(SleepInBoxCoroutine());
    }

    public IEnumerator SleepInBoxCoroutine()
    {
        animator.SetTrigger("Trans");
        yield return new WaitForSeconds(transTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
