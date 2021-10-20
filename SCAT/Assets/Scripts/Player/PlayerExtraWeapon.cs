using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtraWeapon : MonoBehaviour
{

    [SerializeField] private Transform topGun;
    [SerializeField] private Transform bottomGun;

    [SerializeField, Range(-20, 20)] private int step = 1;

    private float deltaTimeMove;
    //private bool isMovePositive = true;
    private int position = 0;
    private PlayerData player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponent<PlayerData>();
        deltaTimeMove = Time.time;
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
