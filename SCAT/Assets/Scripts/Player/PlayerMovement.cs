using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   // [SerializeField] private Transform mainCamera;
    private PlayerData player; 
    private Vector2 velocity;
    
    private void Awake()
    {
        player = GetComponent<PlayerData>();
    }
    void Start()
    {

      //  mainCamera = Camera.main.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = (player.moveDirection).normalized;
        
    }


    private void FixedUpdate()
    {
        player.rb2D.velocity = (velocity  * player.speedMovement);
        //transform.Translate(velocity * Time.fixedDeltaTime * player.speedMovement);     
    }
}
