using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWeapon : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private float reloadSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject pathEnemy;
    private bool isReloading = false;

    // Update is called once per frame
    public void MakeShot()
    {
        var enemy =  Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var script = enemy.GetComponent<SplineWalker>();

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
