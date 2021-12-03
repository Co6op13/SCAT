using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BasicWeapon
{
    private void FixedUpdate()
    {
        if (isReload)
        {
            isReload = false;
            MakeShot(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));         
        }
    }


}
