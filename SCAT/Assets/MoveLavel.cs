using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLavel : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Transform[] pointOfChancheDirection;
    [SerializeField] private int currentPoint;

    private void Start()
    {
        currentPoint = 0;
    }

    void Update()
    {
        Debug.Log(pointOfChancheDirection[currentPoint].position * - 1 +"    "+ Vector3.Distance(Vector3.zero, pointOfChancheDirection[currentPoint].position));
        if (Vector3.Distance (transform.position, pointOfChancheDirection[currentPoint].position * -1) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointOfChancheDirection[currentPoint].position * -1,
                //transform.position - pointOfChancheDirection[currentPoint].position,
                //pointOfChancheDirection[currentPoint+1].position,
                speed *Time.deltaTime);
        }
        else
        {
            if (currentPoint + 1 < pointOfChancheDirection.Length)
                currentPoint++;
        }    
    }
}
