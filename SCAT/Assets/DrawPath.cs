using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DrawPath : MonoBehaviour
{
    [SerializeField] private bool _isActivDrawing;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _extra1;    
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _extra2;
    // [SerializeField] internal Vector3[] _pathPoints;

    [SerializeField, Range(0, 1)] private float step;
    private void OnDrawGizmos()
    {
        if (_isActivDrawing)
        {
            int _sigmentNumber = 20;
            Vector3 _previousPoint = _start.position;

            for (int i = 0; i < _sigmentNumber + 1; i++)
            {
                float _parameter = (float)i / _sigmentNumber;
                Vector3 _point = Besier.GetPoint(_start.position, _extra1.position, _extra2.position, _end.position, _parameter);
                Gizmos.DrawLine(_previousPoint, _point);
                _previousPoint = _point;
            }
        }
    }
}
