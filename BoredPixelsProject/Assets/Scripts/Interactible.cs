using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactible : MonoBehaviour
{
    public GameObject message;
    public Vector3 messageOffset;
    public UnityEvent Interact;

    private bool interacted = false;

    
    void Start()
    {
       
    }

    void Update()
    {
        message.transform.position = Camera.main.WorldToScreenPoint(transform.position + messageOffset);   
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player" && !interacted)
        {
            message.SetActive(true);
            if(Input.GetButtonDown("Interact"))
            {
                Interact.Invoke();
                message.SetActive(false);
                interacted = true;
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "Player" && !interacted)
        {
            message.SetActive(false);
        }
    }
}
