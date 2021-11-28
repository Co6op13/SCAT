using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicWeapon : MonoBehaviour
{
    [SerializeField] protected bool isActive;
    [SerializeField] protected int damage;
    [SerializeField] protected float reloadSpeed;
    [SerializeField] protected bool isReload = true;
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected Transform firePoint;
    protected Transform parentObject;
    public int Damage { set => damage = value; }

    protected virtual void Start()
    {
        parentObject = Camera.main.transform;
    }

    protected void MakeShot(GameObject prefab, Vector3 firePoint, Quaternion quaternion)
    {
        var bullet = Instantiate(prefab, firePoint, quaternion) as GameObject;
        bullet.GetComponent<iProjectile>().SetDamage(damage);
        bullet.transform.parent = parentObject;
    }


    protected IEnumerator  Reload(float waitTime, System.Action<bool> callback)
    {
        yield return new WaitForSeconds(waitTime);
        callback(true);
        yield break;
    }

    void ActivationWeapon()
    {
        isActive = true;
    }
}