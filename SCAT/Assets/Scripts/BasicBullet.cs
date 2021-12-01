using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public abstract class BasicBullet : MonoBehaviour, iProjectile
{
    [SerializeField] protected float lifeTime = 10f;
    [SerializeField] protected int damage;
    [SerializeField] protected float speedMovement = 1;
    protected Rigidbody2D rb2d;
    public float Speed { set => speedMovement = value; }

    protected virtual void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected void Start()
    {
        lifeTime = Time.time + lifeTime;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HP>() != null)
        {
            Debug.Log("hit in " + collision.name);
            collision.gameObject.GetComponent<HP>().GetDamage(damage);
            gameObject.SetActive(false);
        }       
    }

    

}
