using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameData.lives = 3;
        GameData.timer = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
