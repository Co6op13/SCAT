using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponPoint;
    [SerializeField] private PlayerWeaposType currentWeaposType;
    [SerializeField] private GameObject weaponCurrent;
    [SerializeField] private iPlayerWeapon weaponScript;
    [SerializeField] private GameObject[] weapons;
    
    private PlayerData player;
    private void Awake()
    {
        player = GetComponent<PlayerData>();
    }


    private void Start()
    {
      
        SetWeaponType(currentWeaposType);
    }

    private void Update()
    {
        if (player.isShooting)
        {
            weaponScript.MakeShot();
        }
    }

    public void SetWeaponType(PlayerWeaposType weapon)
    {
        try
        {
            weaponCurrent.SetActive(false);
        }
        catch
        {
            Debug.Log("current weapon is empty");
        }
        //Debug.Log(weapon);
        weaponCurrent = weapons[(int)weapon];
        weaponCurrent.SetActive(true);
        weaponScript = weaponCurrent.GetComponent<iPlayerWeapon>();
    }

}
