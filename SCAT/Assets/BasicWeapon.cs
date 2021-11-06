using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private int damage;
    private bool isReloading = false;
    public int Damage { set => damage = value; }

    
    public void MakeShot()
    {
        var bullet =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<iProjectile>().SetDamage(damage);
    }

    private void FixedUpdate()
    {
        if (isActive && !isReloading)
        {
            isReloading = true;
            MakeShot();
            StartCoroutine(Reload());
        }        
    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
    }
}
