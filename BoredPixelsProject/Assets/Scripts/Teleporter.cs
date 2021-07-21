using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform teleportLocation;
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Teleport()
    {
        player.transform.position = teleportLocation.position;
    }
}
