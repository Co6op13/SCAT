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
            if (isDelayEnd)
                LaunchRocket();
        }
    }

    void LaunchRocket()
    {
        isDelayEnd = false;
        MakeShot(bulletPrefab, firePoints[currentFirePoint].position, firePoints[currentFirePoint].rotation);
        StartCoroutine(Reload(delayLaunchRocket, (callback) => isDelayEnd = callback));
        currentFirePoint++;
        if (currentFirePoint == firePoints.Length)
        {
            isReload = false;
            currentFirePoint = 0;
            StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));
        }
    }
}
