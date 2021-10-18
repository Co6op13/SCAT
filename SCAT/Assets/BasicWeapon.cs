using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField] private float fireSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    // Update is called once per frame
    public void MakeShot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
