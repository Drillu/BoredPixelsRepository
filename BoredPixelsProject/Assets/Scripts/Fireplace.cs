using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : MonoBehaviour
{
    public float onTime;
    public float offTime;
    public PlayerMovement player;
    public ParticleSystem fire;

    private bool isOn;

    void Start()
    {
        isOn = false;
        fire.Stop();
        StartCoroutine(TurnOn());
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "fireDetector" && isOn)
        {
            player.gameOver = true;
        }
    }

    IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(onTime);
        fire.Play();
        isOn = true;
        StartCoroutine(TurnOff());
    }

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(offTime);
        fire.Stop();
        isOn = false;
        StartCoroutine(TurnOn());
    }


}
