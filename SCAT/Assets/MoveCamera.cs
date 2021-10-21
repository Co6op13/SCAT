using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform movingObjects;
    [SerializeField] private Transform[] pointOfChancheDirection;
    [SerializeField] private int currentPoint;

    private void Start()
    {
        currentPoint = 0;
    }

    void FixedUpdate()
    {
        //Debug.Log(Vector3.Distance(pointOfChancheDirection[currentPoint].position *  - 1, pointCheck.position));
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
