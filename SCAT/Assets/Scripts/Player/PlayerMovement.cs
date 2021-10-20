using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerData player; 

    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = player.moveDirection;        
    }


    private void FixedUpdate()
    {
       player.rb2D.MovePosition(player.rb2D.position + velocity * Time.fixedDeltaTime * player.speedMovement);
    }
}
