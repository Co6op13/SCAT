using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BezierSnapPoint : MonoBehaviour
{
    [SerializeField] private bool _isSnap;
    [SerializeField] private Transform _extraPoint;
    [SerializeField] private Transform _otherExtraPoint;

    private void Start()
    {
        _extraPoint = transform.GetChild(0).transform;
    }

    private void FixedUpdate()
    {
        if (_isSnap && !_otherExtraPoint)
        {
            _otherExtraPoint.position = _extraPoint.position;
        }        
    }

    public void SetOtherExtraPoint( Transform other)
    {
        _otherExtraPoint = other;
        _isSnap = true;
    }
}
