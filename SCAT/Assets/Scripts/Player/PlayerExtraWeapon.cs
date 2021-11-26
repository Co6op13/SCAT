using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraWeapon : MonoBehaviour
{
    [SerializeField] private float reloadSpeed;
    [SerializeField] private Transform topGun;
    [SerializeField] private Transform topFirePoint;
    [SerializeField] private Transform bottomGun;
    [SerializeField] private Transform bootomFirePoint;
    [SerializeField] private GameObject bulletPrefab;    
    [SerializeField, Range(-20, 20)] private int step = 1;
    private bool isReloading = false;
    private float deltaTimeMove;
    //private bool isMovePositive = true;
    private int position = 0;
    private PlayerData player;
    private Transform parentObject;
    // Start is called before the first frame update
    private void Awake()
    {
        player = transform.GetComponent<PlayerData>();
    }
    void Start()
    {
        parentObject = Camera.main.transform;
        deltaTimeMove = Time.time;
    }

    private void Update()
    {
        if (player.isShooting)
        {
            MakeShoot();
        }
    }

    private void MakeShoot()
    {
        if (!isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());

            var topBullet = Instantiate(bulletPrefab, topFirePoint.position, topFirePoint.rotation)as GameObject ;
            var bootomBullet =  Instantiate(bulletPrefab, bootomFirePoint.position, bootomFirePoint.rotation) as GameObject;
            topBullet.transform.parent = parentObject;
            bootomBullet.transform.parent = parentObject;

        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadSpeed);
        isReloading = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.isExtraGunLocked) 
        {
            MoveGunArround(topGun);            
        };
    }

    void MoveGunArround(Transform gun )
    {
        if (deltaTimeMove < Time.time)
        {
            if (position > 90 || position < -90)
                SwitchDirection();
            deltaTimeMove = Time.time + player.speedMoveExtraGun;
            position = position + step;
            Quaternion topTarget = Quaternion.Euler(0, 0, position);
            Quaternion bootomTarget = Quaternion.Euler(0, 0, -position);
            topGun.rotation = topTarget;
            bottomGun.rotation = bootomTarget;
        }
    }

    void SwitchDirection()
    {
        step *= -1;    
    }
}
