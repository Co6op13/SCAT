using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    private iHP livingObject;
    internal int currentHP;

    private void Start()
    {
        livingObject = GetComponent<PlayerData>();
        currentHP = livingObject.GetMaxHP();
    }       

    public void GetDamage(int damage)
    {
        if (currentHP - damage >= 0)
        {
            currentHP -= damage;
        }
    }

    public void GetHeal(int heal)
    {
        if (currentHP + heal < livingObject.GetMaxHP())
        {
            currentHP += heal;
        }
        else
            currentHP = livingObject.GetMaxHP();
    }
}

