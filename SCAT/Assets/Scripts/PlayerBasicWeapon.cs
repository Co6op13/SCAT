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
    private Transform parentObject;

    private void Start()
    {
        parentObject = Camera.main.transform;
    }

    public void MakeShot()
    {        
        if (!isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
            var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject ;
            bullet.transform.parent = parentObject;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
    }



}
