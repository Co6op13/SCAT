using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DrawExtraLine : MonoBehaviour
{
    [SerializeField] private Transform _parentPoint;

    private void Start()
    {
        _parentPoint = transform.parent.transform;
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_parentPoint.position, transform.position);
    }
}
