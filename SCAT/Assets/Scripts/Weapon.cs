using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BasicWeapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private void FixedUpdate()
    {
        
           // StopCoroutine(Reload(reloadSpeed));
        if (isActive && isReload)
        {
            isReload = false;
            MakeShot(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));
            //StopCoroutine(Reload());
        }

        



    }
}
