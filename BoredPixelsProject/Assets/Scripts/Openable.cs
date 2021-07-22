using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openable : MonoBehaviour
{
    public Sprite openedSprite;
    public string type;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = openedSprite;
        gameObject.GetComponent<Collider2D>().enabled = false;
        FindObjectOfType<AudioManager>().Play(type + "Open");
    }
}
