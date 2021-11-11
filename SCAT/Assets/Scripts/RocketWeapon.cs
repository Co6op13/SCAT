using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : BasicWeapon
{
    [SerializeField] private float delayLaunchRocket;
    [SerializeField] private Transform[] firePoints;
    [SerializeField] private GameObject bulletPrefab;
    private bool isDelayEnd = true;
    private int currentFirePoint;


    private void FixedUpdate()
    {
        if (isActive && isReload)
        {
            isReload = false;
            StartCoroutine(LR());
            
            //StopCoroutine(Reload());
        }
        //if (isActive && isReload)
        //{
        //    if (isDelayEnd)
        //        LaunchRocket();
        //}
    }

    //void LaunchRocket()
    //{
    //    isDelayEnd = false;
    //    MakeShot(bulletPrefab, firePoints[currentFirePoint].position, firePoints[currentFirePoint].rotation);
    //    StartCoroutine(Reload(delayLaunchRocket, (callback) => isDelayEnd = callback));
    //    currentFirePoint++;
    //    if (currentFirePoint == firePoints.Length)
    //    {
    //        isReload = false;
    //        currentFirePoint = 0;
    //        StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));
    //    }
    //}

    private IEnumerator LR()
    {
        foreach (var firePoint in firePoints)
        {
            MakeShot(bulletPrefab, firePoint.position, firePoint.rotation);
            yield return new WaitForSeconds(delayLaunchRocket);
        }
        StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));
        yield break;
    }
}
