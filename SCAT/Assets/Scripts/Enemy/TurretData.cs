using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Scripts
{
    public class TurretData : MonoBehaviour
    {
        //[SerializeField] private bool isActive;
        [SerializeField, Range(0, 359)] private float maxAngleWeapon;
        [SerializeField, Range(0, 359)] private float minAngleWeapon;
        [SerializeField] private float speedRotation;
        //[SerializeField] internal int maxHP;
        [SerializeField] internal Transform target;
        [SerializeField] private float timeBetweenMoveWeapon = 0.3f;
        [SerializeField] private Transform pivotWeapon;
        [SerializeField] private GameManager playersPool;
        private float timeMove;
        private float timeSearch = 0.1f;
        [SerializeField] private float maxDirectionAngle;
        [SerializeField] private float minDirectionAngle;
        [SerializeField] private float targetDirectionAngle = 90;

        private void Awake()
        {
            playersPool = FindObjectOfType<GameManager>();
        }


        private void Start()
        {
            timeMove = Time.time + timeMove;
            target = playersPool.GetNearestTarger(transform.position);
            maxDirectionAngle = GetRangePositionWeapon(maxAngleWeapon);
            minDirectionAngle = GetRangePositionWeapon(minAngleWeapon);
        }

        private float GetRangePositionWeapon(float dir)
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
            float directionAngle = GeneralMetods.GetAngleFromVectorFloat(direction);

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

        void MoveWeapon(float directionAngle)
        {
            pivotWeapon.rotation = Quaternion.Slerp(pivotWeapon.rotation,
                Quaternion.Euler(0f, 0f, directionAngle - 90), speedRotation );

        }


        private void OnDrawGizmos()
        {
            Debug.DrawRay(transform.position, GeneralMetods.GetVectorFromAngle
                (targetDirectionAngle) * 5, Color.white);
            Debug.DrawRay(transform.position, GeneralMetods.GetVectorFromAngle(maxAngleWeapon +
                transform.eulerAngles.z) * 3, Color.red);
            Debug.DrawRay(transform.position, GeneralMetods.GetVectorFromAngle(minAngleWeapon +
                transform.eulerAngles.z) * 3, Color.blue);
        }

        //public void ActivationObject()
        //{
        //    isActive = true;
        //}
    }
}