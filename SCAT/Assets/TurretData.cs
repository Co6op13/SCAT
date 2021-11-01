using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretData : MonoBehaviour, iHP
{
    //[SerializeField] private bool isActive;

    [SerializeField] internal int maxHP;
    [SerializeField] internal Transform target;
    [SerializeField] private float timeBetweenSearch = 0.5f;
    [SerializeField] private float rangeMoveWeapon = 30;
    [SerializeField] private Transform pivotWeapon;
    [SerializeField] private float speedRotate;
    internal CompositeCollider2D collider2d;
    [SerializeField] private PlayersPool playersPool;
    private float time;
    private float maxDirectionAngle;
    private float minDirectionAngle;
    private float targetDirectionAngle = 90;
   
   // [SerializeField] private Vector3 targetDirection = Vector3.up;


    private void Start()
    {
        targetDirectionAngle = transform.eulerAngles.z + 90;
        playersPool = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayersPool>();
        time = Time.time + 1f;
        target = playersPool.GetNearestTarger(transform.position);
        GetRangePositionWeapon();
    }

    private void GetRangePositionWeapon()
    {
       
        maxDirectionAngle = transform.eulerAngles.z + 90 + rangeMoveWeapon;
        minDirectionAngle = transform.eulerAngles.z + 90 - rangeMoveWeapon;
      
    }

    private void FixedUpdate()
    {
        if (time < Time.time)
        {
            Debug.Log(time + "   " + Time.time);
            if (target == null)
            {
                target = playersPool.GetNearestTarger(transform.position);
            }
            time = Time.time + timeBetweenSearch;
            targetDirectionAngle = GetDirection(target);
        }

        Debug.DrawRay(transform.position, GetVectorFromAngle(targetDirectionAngle) * 5, Color.red);    
        MoveWeapon(targetDirectionAngle);
    }

    private float GetDirection(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        float directionAngle = GetAngleFromVectorFloat(direction);
        if (directionAngle < minDirectionAngle)
        {
            return minDirectionAngle;
        }
        else if ( directionAngle > maxDirectionAngle)
        {
            return maxDirectionAngle;
        }
        else
            return directionAngle;
    }

    void MoveWeapon( float directionAngle)
    {

        pivotWeapon.localRotation = Quaternion.Slerp(pivotWeapon.localRotation,
            Quaternion.Euler(0f,0f , directionAngle + 90), speedRotate * Time.fixedDeltaTime);
    }
    public int GetMaxHP()
    {
        return (maxHP);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, GetVectorFromAngle( maxDirectionAngle) * 3 , Color.gray);
        Debug.DrawRay(transform.position, GetVectorFromAngle( minDirectionAngle) * 3 , Color.gray);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }


    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;

        return angle;
    }
}
