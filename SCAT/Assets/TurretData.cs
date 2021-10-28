using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Co6op13Lib.direct;


public class TurretData : MonoBehaviour, iHP
{
    //[SerializeField] private bool isActive;
    [SerializeField] internal int maxHP;
    internal CompositeCollider2D collider2d;
    [SerializeField] internal Transform[] playersTransform;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playersTransform = new Transform[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playersTransform[i] = players[i].transform;
        }

        Debug.Log(DirectionCo6op13.SumTest(1, 2 ));
        //Class1.Equals
        //Co6op13.Class1.Sum(1, 2);
        //Co6op13.Class1.
      //  Debug.Log( Co6op13.Class1. (1, 2));
    }


    public int GetMaxHP()
    {
        return (maxHP);
    }
}
