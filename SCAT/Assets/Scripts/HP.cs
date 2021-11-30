using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour
{
    [SerializeField] internal int currentHP;
    [SerializeField] private GameObject prefabDie;
    [SerializeField] private GameObject parentObject;  // if need
    [SerializeField] private HP parentHP;
    [SerializeField] private bool isChildrenObject = false;
    private iHP livingObject;

    private void Awake()
    {
        if (GetComponent<iHP>() != null)
        {
            livingObject = GetComponent<iHP>();
        }
        else
        {
            livingObject = parentObject.GetComponent<iHP>();
        }
    }
    private void Start()
    {
        currentHP = livingObject.GetMaxHP();
    }

    public void GetDamage(int damage)
    {
        if (isChildrenObject == true)
        {
            parentHP.GetDamage(damage);
            return;
        }
        else
        {
            if (currentHP - damage >= 0)
            {
                currentHP -= damage;
            }
            else
            {
                try
                {
                    Instantiate(prefabDie, transform.position, transform.rotation);
                }
                catch
                {
                    Debug.Log(gameObject.name + " prefab Die is empty");
                }
                Destroy(gameObject);
            }
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
