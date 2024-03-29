using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] internal bool isAlive = true;
    [SerializeField] internal float speedMovement;    
    [SerializeField, Range(0.01f,0.1f)] internal float speedMoveExtraGun = 0.05f;
    [SerializeField] internal bool isExtraGunLocked = false;
    [SerializeField] private GameManager playersPool;

    internal HP health;
    internal PlayerInput input;
    internal PlayerExtraWeapon extraWeapon;
    internal PlayerWeapon weapon;
    internal Rigidbody2D rb2D;
    internal BoxCollider2D _collider2D;
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

    void OnDestroy()
    {
        playersPool.DeletePlayer(transform);
    }


    // Start is called before the first frame update
    void Awake()
    {
        playersPool.AddPlayer(transform);
        input = GetComponent<PlayerInput>();
        rb2D = GetComponent<Rigidbody2D>();
    }
}
