using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    public float groundSpeed;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void FixedUpdate()
    {
        transform.position -= new Vector3(groundSpeed * Time.fixedDeltaTime, 0, 0);

        if(transform.position.x <= -18)
        {
            transform.position = startPosition;
        }

    }
}
