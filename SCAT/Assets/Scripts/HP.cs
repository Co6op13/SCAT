using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour
{
    private iHP livingObject;
    [SerializeField] internal int currentHP;
    [SerializeField] private GameObject prefabDie;

    private void Awake()
    {
        livingObject = GetComponent<iHP>();
    }
    private void Start()
    {
           
            currentHP = livingObject.GetMaxHP();
    }

    public void GetDamage(int damage)
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
