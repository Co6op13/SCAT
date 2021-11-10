using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWeapon : MonoBehaviour
{
    [SerializeField] private PlayerWeaposType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.gameObject.GetComponent<PlayerWeapon>() != null)
        {
            collision.gameObject.GetComponent<PlayerWeapon>().SetWeaponType(type);
            Destroy(gameObject);
        }

    }
}
