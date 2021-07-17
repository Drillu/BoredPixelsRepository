using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject textToShow;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textToShow.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textToShow.SetActive(false);
    }
}
