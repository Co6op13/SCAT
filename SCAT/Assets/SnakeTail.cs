using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private Transform previosBone;
    [SerializeField] private float speedMovement;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = previosBone.position * Time.deltaTime;
        
    }
}
