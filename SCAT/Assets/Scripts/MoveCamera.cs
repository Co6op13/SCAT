using System;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private Transform movingObjects;
    [SerializeField] private Transform[] pointOfChancheDirection;
    //[SerializeField] private record(Vector3 pointOfChancheDirection, float speed);
    [SerializeField] private int currentPoint;
  



private void Start()
    {
        currentPoint = 0;
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(movingObjects.position, pointOfChancheDirection[currentPoint].position) > 0.1f)
        {
            movingObjects.position = Vector3.MoveTowards(movingObjects.position,
                pointOfChancheDirection[currentPoint].localPosition,
                speed * Time.fixedDeltaTime);
        }
        else
        {
            if (currentPoint + 1 < pointOfChancheDirection.Length)
                currentPoint++;
        }
    }

}
