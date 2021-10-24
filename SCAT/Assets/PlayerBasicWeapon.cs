using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicWeapon : MonoBehaviour , iPlayerWeapon
{
    //[SerializeField] private bool isActive;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    //[SerializeField] private int damage;
    [SerializeField] private bool isReloading = false;

    //public int Damage { set => damage = value; }

    // Update is called once per frame
    public void MakeShot()
    {
        Debug.Log("try Shooting");
        if (!isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
            //var bullet =
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //bullet.GetComponent<iProjectile>().SetDamage(damage);
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
    }


}
