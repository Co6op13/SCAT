using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenHP : MonoBehaviour,iHP
{
    [SerializeField] private HP parentHP;
    [SerializeField] private int defence;

    private void Start()
    {
        if (parentHP == null)
            Debug.LogWarning(parentHP + "is emptu on gameobjetc name - " + gameObject.name);
    }
    public void GetDamage(int damage)
    {       
        if (damage - defence > 0)
        {
            damage -= defence;
        }
        else
        {
            damage = 1;
        }
        parentHP.GetDamage(damage);
    }
}
