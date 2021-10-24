using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyData : MonoBehaviour,iHP
{

    [SerializeField] internal int maxHP;
    [SerializeField] internal float speedMovemet;
    public int GetMaxHP()
    {
        return (maxHP);
    }


}
