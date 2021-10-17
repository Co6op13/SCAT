using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

[EditorTool("Snap Bezier ", typeof(BezierSnapPoint))]
public class BezierSnappingTool : EditorTool
{

    private Transform oldTarget;
    private BezierSnapPoint[] allPoints;
    private BezierSnapPoint[] targetPoints;



    public override void OnToolGUI(EditorWindow window)
    {
        //Transform targetTransform = ((BezierSnapPoint)target).transform;
        GameObject target = ((BezierSnapPoint)base.target).gameObject;

        if (target != oldTarget)
        {
            PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(target.gameObject);

            if (prefabStage != null)
                allPoints = prefabStage.prefabContentsRoot.GetComponentsInChildren<BezierSnapPoint>();
            else
                allPoints = FindObjectsOfType<BezierSnapPoint>();

            targetPoints = target.GetComponentsInChildren<BezierSnapPoint>();

            oldTarget = target.transform;
        }

        EditorGUI.BeginChangeCheck();
        Vector3 newPosition = Handles.PositionHandle(target.transform.position, Quaternion.identity);

        if (EditorGUI.EndChangeCheck())
        {
            Undo.RecordObject(target, "Move with custom snap tool");

           // if (((BezierSnapPoint)target).IsGrounded) newPosition.y = 0;

            MoveWithSnapping(target, newPosition);
        }
    }

    private void MoveWithSnapping(GameObject target, Vector3 newPosition)
    {
        Vector3 bestPosition = newPosition;
       // int bestPointIndex = 0;
       // int i = 0;
        float closestDistance = float.PositiveInfinity;

        foreach (BezierSnapPoint point in allPoints)
        {
         //   i = 0;
            if (point.transform.parent == target) continue;

            foreach (BezierSnapPoint ownPoint in targetPoints)
            {
              //  i++;
                //if (ownPoint.Type != point.Type) continue;

                Vector3 targetPos = point.transform.position - (ownPoint.transform.position - target.transform.position);
                float distance = Vector3.Distance(targetPos, newPosition);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                   // bestPointIndex = i;
                    bestPosition = targetPos;
                }
            }
        }

        if (closestDistance < 0.5f)
        {
            target.transform.position = bestPosition;
            //GameObject bestPoin = targetPoints[i].GetComponent<GameObject>();
            //target.GetComponent<BezierSnapPoint>().SetOtherExtraPoint(bestPoin.transform);
            //bestPoin.GetComponent<BezierSnapPoint>().SetOtherExtraPoint(target.transform);            
        }
        else
        {
            target.transform.position = newPosition;
        }
    }
}

