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
    internal CompositeCollider2D collider2d;
    [SerializeField] private PlayersPool playersPool;
    private float time;
    private float maxAnglePosiotonWeapon;
    private float minAnglePosiotonWeapon;
    [SerializeField] private Vector3 maxDirection;
    [SerializeField] private Vector3 minDirection;
    [SerializeField] private Vector3 targetDirection;


    private void Start()
    {
        playersPool = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayersPool>();
        time = Time.time + timeBetweenSearch;
        GetRangePositionWeapon();
    }

    private void GetRangePositionWeapon()
    {
        maxAnglePosiotonWeapon = transform.rotation.z + 90 + rangeMoveWeapon;
        minAnglePosiotonWeapon = transform.rotation.z + 90 - rangeMoveWeapon;
        maxDirection = GetVectorFromAngle(maxAnglePosiotonWeapon);
        minDirection = GetVectorFromAngle(minAnglePosiotonWeapon);       
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
        }

        targetDirection = GetDirection(target);
        MoveWeapon();
    }

    private Vector3 GetDirection(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Debug.DrawLine(transform.position, direction + transform.position, Color.red);
        return direction;
    }

    void MoveWeapon()
    {

    }
    public int GetMaxHP()
    {
        return (maxHP);
    }

    private void OnDrawGizmos()
    {
        Debug.DrawLine(transform.position, maxDirection + transform.position);
        Debug.DrawLine(transform.position, minDirection + transform.position);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
