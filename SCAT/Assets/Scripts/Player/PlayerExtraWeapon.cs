using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraWeapon : BasicWeapon
{
    [SerializeField] private Transform topGun;
    [SerializeField] private Transform topFirePoint;
    [SerializeField] private Transform bottomGun;
    [SerializeField] private Transform bootomFirePoint;
    [SerializeField, Range(-20, 20)] private int step = 1;
    private float deltaTimeMove;
    private int position = 0;
    private PlayerData player;
    private void Awake()
    {
        player = transform.GetComponent<PlayerData>();
    }
    protected override void Start()
    {
        deltaTimeMove = Time.time;
        base.Start();
    }

    private void Update()
    {
        if (player.isShooting)
        {
            TryMakeShoot();
        }
    }

    private void TryMakeShoot()
    {
        if (isReload)
        {
            isReload = false;
            MakeShot(bulletPrefab, topFirePoint.position, topFirePoint.rotation);
            MakeShot(bulletPrefab, bootomFirePoint.position, bootomFirePoint.rotation);
            StartCoroutine(Reload(reloadSpeed, (callback) => isReload = callback));            
        }
    }

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
