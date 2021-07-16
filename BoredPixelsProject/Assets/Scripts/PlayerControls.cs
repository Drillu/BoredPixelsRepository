using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls: MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 movement = Vector2.zero;
    public float moveSpeed=5f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        }
        
    }
}
