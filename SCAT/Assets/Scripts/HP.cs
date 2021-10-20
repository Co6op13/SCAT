using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour
{
    private iHP livingObject;
    [SerializeField] internal int currentHP;

    private void Start()
    {
        livingObject = GetComponent<iHP>();
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
