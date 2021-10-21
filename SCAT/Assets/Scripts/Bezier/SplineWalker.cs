using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineWalker : MonoBehaviour, iActivation
{
    [SerializeField] private bool isActiv = false;
    const float normalizedSpeed = 0.01f;
    [SerializeField] private SplineWalkerMode mode;    
    [SerializeField] private BezierSpline path;
    [SerializeField] float speedMovement;
    [SerializeField] private bool lookForward;
    [SerializeField] private bool goingForward = true;
    [SerializeField] private float progress;
    private Vector3 position;

    public BezierSpline Path {set => path = value; }
    
    public float SpeedMovement {set => speedMovement = value; }
    public bool IsActiv {get => isActiv;}

    private void Start()
    {
        if (path == null)
        {
            Debug.LogError("Path is empty");
        }
    }
    private void Update()
    {
        if (isActiv)
        {
            if (goingForward)
            {
                progress += speedMovement * normalizedSpeed * Time.deltaTime;
                if (progress > 1f)
                {
                    if (mode == SplineWalkerMode.Once)
                    {
                        progress = 1f;
                    }
                    else if (mode == SplineWalkerMode.Loop)
                    {
                        progress -= 1f;
                    }
                    else
                    {
                        progress = 2f - progress;
                        goingForward = false;
                    }
                }
            }
            else
            {
                progress -= speedMovement * normalizedSpeed * Time.deltaTime;
                if (progress < 0f)
                {
                    progress -= progress;
                    goingForward = true;
                }

            }
            // Debug.Log(progress);
            position = path.GetPoint(progress);
            if (lookForward)
            {
                transform.LookAt(position + path.GetDirection(progress));
            }
        }
    }

    private void FixedUpdate()
    {
        if (isActiv)
        transform.localPosition = position;
    }

    public void ActivationObject()
    {
        isActiv = true;
    }
}
