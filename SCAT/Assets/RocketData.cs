using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketData : MonoBehaviour, iHP
{
    private int maxHp = 1;
    public int GetMaxHP()
    {
        return maxHp;
    }
}
