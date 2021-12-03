using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketWeapon : BasicWeapon
{    
    [SerializeField] private float delayLaunchRocket;
    [SerializeField] private Transform[] firePoints;


    private void FixedUpdate()
    {
        if ( isReload)
        {
            isReload = false;
            StartCoroutine(LaunchRocket());
        }
    }

    private IEnumerator LaunchRocket()
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
