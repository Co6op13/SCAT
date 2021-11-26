using System;
using System.Collections.Generic;
using UnityEngine;


public class MoveCamera : MonoBehaviour
{
    [Serializable]
    public struct PointOfChancheDirection
    {
        public Vector2 point;
        public float speedToPoint;
    }

    [SerializeField] private float currentSpeed;
    [SerializeField] private Transform movingObjects;
    [SerializeField] private List<PointOfChancheDirection> pointOfChancheDirection;
    [SerializeField] private int currentPoint;
    private Vector3 nextPoint;


    public float CurrentSpeed { get => currentSpeed;}

    private void Start()
    {
        currentPoint = 0;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(movingObjects.position, 
            pointOfChancheDirection[currentPoint].point) > 0.1f)
        {
            movingObjects.position = Vector3.MoveTowards(movingObjects.position, nextPoint,
                currentSpeed * Time.fixedDeltaTime);
        }
        else
        {
            if (currentPoint + 1 < pointOfChancheDirection.Count)
            {
                currentPoint++;
                nextPoint = new Vector3(pointOfChancheDirection[currentPoint].point.x,
                    pointOfChancheDirection[currentPoint].point.y,
                    movingObjects.position.z);

                currentSpeed = pointOfChancheDirection[currentPoint].speedToPoint;                
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        for (int i = 1; i < pointOfChancheDirection.Count; i++)
        {
            Gizmos.DrawLine(pointOfChancheDirection[i - 1].point,
                pointOfChancheDirection[i].point);
        }
    }
}
