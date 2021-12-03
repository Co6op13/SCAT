using UnityEngine;
using System.Collections;

public class HP : MonoBehaviour,iHP
{
    [SerializeField] private int maxHP;
    [SerializeField] internal int currentHP;
    [SerializeField] private GameObject prefabDie;

    private void OnEnable()
    {
        currentHP = maxHP;
    }

    public void GetDamage(int damage)
    {
        if (currentHP - damage >= 0)
        {
            currentHP -= damage;
        }
        else
        {
            currentHP = 0;
            try
            {
                Instantiate(prefabDie, transform.position, transform.rotation);
            }
            catch
            {
                Debug.Log(gameObject.name + " prefab Die is empty");
            }
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void GetHeal(int heal)
    {
        if (currentHP + heal < maxHP)
        {
            currentHP += heal;
        }
        else
            currentHP = maxHP;
    }
}
