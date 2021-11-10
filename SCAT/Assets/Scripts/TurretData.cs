using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurretData : MonoBehaviour, iHP
{
    [SerializeField] private bool isActive;
    [SerializeField, Range(0, 359)] private float maxAngleWeapon;
    [SerializeField, Range(0, 359)] private float minAngleWeapon;
    [SerializeField] private float speedRotate;
    [SerializeField] internal int maxHP;
    [SerializeField] internal Transform target;
    [SerializeField] private float timeBetweenSearch = 1f;
    [SerializeField] private float timeBetweenMoveWeapon = 0.3f;
    [SerializeField] private Transform pivotWeapon;
   // internal CompositeCollider2D collider2d;
    [SerializeField] private PlayersPool playersPool;
    private float timeMove;
    private float timeSearch;
    [SerializeField] private float maxDirectionAngle;
    [SerializeField] private float minDirectionAngle;
    [SerializeField] private float targetDirectionAngle = 90;

    private void Awake()
    {
        playersPool = FindObjectOfType<PlayersPool>();
    }


    private void Start()
    {
        timeMove = Time.time + timeMove;
        target = playersPool.GetNearestTarger(transform.position);       
        maxDirectionAngle = GetRangePositionWeapon(maxAngleWeapon);
        minDirectionAngle = GetRangePositionWeapon(minAngleWeapon);
       
    }

    private  float GetRangePositionWeapon(float dir)
    {
        float newAngle = transform.eulerAngles.z + dir;
        if (newAngle >= 360)
            newAngle -= 360;
        return newAngle;
    }

    private void FixedUpdate()
    {
        
        if (timeMove < Time.time)
        {
            if (timeSearch < Time.time || target == null)
            {
                try
                {
                    target = playersPool.GetNearestTarger(transform.position);
                }
                catch
                {
                    Debug.Log("There is no live player or somthing wrong");
                }

                timeSearch = Time.time + timeSearch;
            }            
            timeMove = Time.time + timeBetweenMoveWeapon;
            if (target != null)
                targetDirectionAngle = GetDirection(target);
        }

        
        MoveWeapon(targetDirectionAngle);
    }

    private float GetDirection(Transform target)
    {
       
        Vector3 direction = (target.position - transform.position).normalized;
        float directionAngle = GetAngleFromVectorFloat(direction);



        //Debug.Log(pivotWeapon.eulerAngles.z);
        if (maxDirectionAngle < minDirectionAngle)
        {
            if (directionAngle < minDirectionAngle & directionAngle > 180f)
            {
                return minDirectionAngle;
            }
            else if (directionAngle > maxDirectionAngle & directionAngle < 180)
            {
                return maxDirectionAngle;
            }
            else
                return directionAngle;
        }
        else
        {

            if (directionAngle < maxDirectionAngle & directionAngle > minDirectionAngle)
                return directionAngle;
            else
            {
                if (directionAngle < minDirectionAngle)
                {
                    return minDirectionAngle;
                }
                else if (directionAngle > maxDirectionAngle)
                {
                    return maxDirectionAngle;
                }
            }
        }
        return (0);        
    }

    void MoveWeapon( float directionAngle)
    {
        //Debug.Log(directionAngle);
        pivotWeapon.rotation = Quaternion.Slerp(pivotWeapon.rotation,
            Quaternion.Euler(0f,0f , directionAngle - 90), speedRotate * Time.fixedDeltaTime);
        
    }

    public int GetMaxHP()
    {
        return (maxHP);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, GetVectorFromAngle(targetDirectionAngle) * 5, Color.red);
        Debug.DrawRay(transform.position, GetVectorFromAngle( maxAngleWeapon + 
            transform.eulerAngles.z ) * 3 , Color.white);
        Debug.DrawRay(transform.position, GetVectorFromAngle( minAngleWeapon + 
            transform.eulerAngles.z ) * 3 , Color.black);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }


    public static int GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        int angle = (int) (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
        if (angle < 0) angle += 360;

        return angle;
    }
}
