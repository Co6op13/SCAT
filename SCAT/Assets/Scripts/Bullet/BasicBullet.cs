using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public abstract class BasicBullet : MonoBehaviour, iProjectile
{
    [SerializeField] protected int damage;
    [SerializeField] protected float speedMovement = 1;
    protected Rigidbody2D rb2d;
    public float Speed { set => speedMovement = value; }

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            gameObject.SetActive(false);
        }

        if (collision.gameObject.GetComponent<iHP>() != null)
        {
            //Debug.Log("hit in " + collision.name);
            collision.gameObject.GetComponent<iHP>().GetDamage(damage);
            gameObject.SetActive(false);
        }       
    }

   


}
