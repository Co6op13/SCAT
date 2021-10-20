using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponPoint;    
    [SerializeField] private iPlayerWeapon weaponCurrent;

    private PlayerData player;
    public void SetWeaponType(iPlayerWeapon weapon)
    {
        weaponCurrent = weapon;
    }

    private void Start()
    {
        player = GetComponent<PlayerData>();
        //weaponCurrent = 
    }

    private void Update()
    {
        //if ()
    }


}
