using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraWeapon : MonoBehaviour
{

    [SerializeField] private Transform _topGun;
    [SerializeField] private Transform _bottomGun;

    [SerializeField, Range(-20, 20)] private int step = 1;

    private float _deltaTimeMove;
    private bool _isMovePositive = true;
    private int position = 0;
    private PlayerData _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = transform.GetComponent<PlayerData>();
        _deltaTimeMove = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_player.isExtraGunLocked) 
        {
            MoveGunArround(_topGun);
            
        }
       // Debug.Log(Time.time);
    }

    void MoveGunArround(Transform gun )
    {
        if (_deltaTimeMove < Time.time)
        {
            if (position > 90 || position < -90)
                SwitchDirection();
           // Debug.Log(_deltaTimeMove);
            _deltaTimeMove = Time.time + _player._speedMoveExtraGun;
            position = position + step;
            Quaternion topTarget = Quaternion.Euler(0, 0, position);
            Quaternion bootomTarget = Quaternion.Euler(0, 0, -position);
            _topGun.rotation = topTarget;
            _bottomGun.rotation = bootomTarget;
        }
    }

    void SwitchDirection()
    {
        step *= -1;    
    }
}
