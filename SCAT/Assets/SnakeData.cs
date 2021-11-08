using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeData : MonoBehaviour
{
    [SerializeField] private float distanceBetweenSegments;
    [SerializeField] private Transform[] tails;
    [SerializeField] internal Transform target;
    [SerializeField] internal int maxHP;
    [SerializeField] private int smoothSpeed;
    private List<Vector2> positionHistory;
    

    void Start()
    {
        positionHistory = new List<Vector2>();        
    }

    void FixedUpdate()
    {
        MoveTail(transform.position);

    }

    private void MoveTail(Vector3 newPosition)
    {
        positionHistory.Insert(0, newPosition);
        int i = 0;
        foreach (var bone in tails)
        {
            Vector3 point = positionHistory[Mathf.Min(i * smoothSpeed, positionHistory.Count - 1)];
            bone.transform.position = point;
            i++;
        }
    }
            
}
