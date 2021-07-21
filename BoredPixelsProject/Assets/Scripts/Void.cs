using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name=="Player")
        {
            other.GetComponent<PlayerMovement>().gameOver = true;
        }
        else if(other.name=="Enemy")
        {
            other.GetComponent<EnemyAi>().isDied = true;
        }
    }
}
