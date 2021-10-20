using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour, iHP
{
    [SerializeField] internal bool isAlive = true;
    [SerializeField] internal float speedMovement;
    [SerializeField] internal int maxHP;
    [SerializeField, Range(0.01f,0.1f)] internal float speedMoveExtraGun = 0.05f;

    [SerializeField] internal bool isExtraGunLocked = false;
    

    internal HP health;
    internal PlayerInput input;
    internal PlayerExtraWeapon extraWeapon;
    internal PlayerWeapon weapon;
    internal Rigidbody2D rb2D;
    internal BoxCollider2D collider2D;
    internal Vector2 moveDirection;
    internal bool isShooting = false;
    public bool IsAlive
    {
        get => isAlive;
        set
        {
            if (health.currentHP > 0)
                isAlive = true;
            else
                isAlive = false;
        }
    }

    public int GetMaxHP()
    {
        return maxHP;
    }

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
