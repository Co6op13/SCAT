using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class BesierTest : MonoBehaviour
{
    [SerializeField] GameObject _path;
    [SerializeField] internal Vector3[] _pathPoints;

    [SerializeField, Range(0, 1)] private float step;
    private void Start()
    {
        Debug.Log(_path.transform.childCount);
        _pathPoints = new Vector3[_path.transform.childCount];
        for (int i = 0; i < _path.transform.childCount; i++)
        {
            _pathPoints[i] = _path.transform.GetChild(i).transform.position;
        }
    }


    private void FixedUpdate()
    {
        transform.position = Besier.GetPoint(_pathPoints[0], _pathPoints[1], _pathPoints[2],
            _pathPoints[3], step);
    }


   
}
