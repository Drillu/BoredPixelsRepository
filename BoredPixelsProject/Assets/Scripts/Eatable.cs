using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public Sprite eatenSprite;
    public GameObject spawningEnemyPrefab;
    public Vector3 enemyOffset;
    public PlayerMovement playerMovement;

    private GameObject spawningEnemy;
    private bool eaten = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Eat()
    {
        if(!eaten)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = eatenSprite;
            spawningEnemy = Instantiate(spawningEnemyPrefab);
            spawningEnemy.transform.position = transform.position + enemyOffset;
            spawningEnemy.name = "Enemy";
            if(playerMovement.lives<9)
            {
                playerMovement.lives += 1;
            }
            eaten = true;
        }
        
    }
}
