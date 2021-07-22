using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotive : MonoBehaviour
{
    public float positionChangeX;
    public float lerpDuration;

    private float startPositionX;
    private float finalPositionX;
    void Start()
    {
        startPositionX = transform.position.x;
        finalPositionX = startPositionX + positionChangeX;
        
    }

    public void Go()
    {
        StartCoroutine(Lerp());
    }

    public IEnumerator Lerp()
    {
        float timeElapsed = 0;

        while (timeElapsed < lerpDuration)
        {
            transform.position = new Vector2(Mathf.Lerp(startPositionX, finalPositionX, timeElapsed / lerpDuration), transform.position.y); 
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = new Vector2(finalPositionX, transform.position.y);
    }

}
