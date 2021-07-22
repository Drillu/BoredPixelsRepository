using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesPanel : MonoBehaviour
{
    public GameObject player;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private int lives;
    private int lastLives;
    private Transform[] hearts = new Transform[9];

    void Start()
    {
        for(int i=0; i<9; i++)
        {
            hearts[i] = transform.GetChild(i);
        }

        lives = player.GetComponent<PlayerMovement>().lifes;
        lastLives = lives;
    }

    
    void Update()
    {
        lives = player.GetComponent<PlayerMovement>().lifes;

        if(lastLives!=lives)
        {
            for(int i=0; i<9; i++)
            {
                if(i < lives)
                {
                    hearts[i].GetComponent<Image>().sprite = fullHeart;
                }
                else
                {
                    hearts[i].GetComponent<Image>().sprite = emptyHeart;
                }
            }
            lastLives = lives;
        }
    }
}
