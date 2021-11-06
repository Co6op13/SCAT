using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLavel : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform movingObjects;
    [SerializeField] private Transform pointCheck;
    //[SerializeField] private Vector3 direction;
    [SerializeField] private Transform[] pointOfChancheDirection;
    
    [SerializeField] private int currentPoint;

    private void Start()
    {
        currentPoint = 1;
    }

    void FixedUpdate()
    {    
        if (Vector3.Distance(pointOfChancheDirection[currentPoint].position * -1, pointCheck.position) > 0.1f)
        {          
            movingObjects.position = Vector2.MoveTowards(movingObjects.position, 
                pointOfChancheDirection[currentPoint].localPosition * -1,
                speed * Time.fixedDeltaTime);
        }
        else
        {           
            if (currentPoint + 1 < pointOfChancheDirection.Length)
                currentPoint++;
        }
    }
}
