using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicWeapon : BasicWeapon , iPlayerWeapon
{
    public void TryMakeShot()
    {
        if (isReload)
        {
            isReload = false;
            MakeShot(bulletPrefab, firePoint.position, firePoint.rotation);
            StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));
        }
    }
}
