using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicWeapon : MonoBehaviour , iPlayerWeapon
{
    //[SerializeField] private bool isActive;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private bool isReloading = false;

    public void MakeShot()
    {        
        if (!isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);            
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
    }



}
