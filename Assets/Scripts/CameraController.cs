using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 offset = new Vector3(0, 4.5f,2.5f); //Make a first-person camera so make the camera to be offset from the players (x at center, y half unit up from the center, z forward 0.25f os it is a little in front of the player)

    void Start()
    {
        
    }


    void LateUpdate()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null) return;
        }
        transform.position = player.transform.position + offset; //Set the position of the camera to the player position and then move the camera a little bit based on the offset
        transform.rotation = player.transform.rotation;
    }
}
