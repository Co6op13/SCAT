using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tentacle : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private float lengthSegment;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private float trailSpeed;
    [Space(5)]
    [SerializeField] private float wiggleSpeed;
    [SerializeField] private float wiggleMagnityde;
    [SerializeField] private Transform wiggleDirection;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Vector3[] segmentPosition;
    [SerializeField] private Transform targetDirection;


    

    private Vector3[] segmentVelocity;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = length;
        segmentPosition = new Vector3[length];
        segmentVelocity = new Vector3[length];
    }

    private void Update()
    {
        wiggleDirection.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.deltaTime * wiggleSpeed) * wiggleMagnityde);
        segmentPosition[0] = targetDirection.position;

        for (int i = 1; i < segmentPosition.Length; i++)
        {
            segmentPosition[i] = Vector3.SmoothDamp(segmentPosition[i], segmentPosition[i - 1] + targetDirection.right * lengthSegment,ref segmentVelocity[i], smoothSpeed);
        }

        lineRenderer.SetPositions(segmentPosition);
    }



}
