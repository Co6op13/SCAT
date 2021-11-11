using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public abstract class BasicBullet : MonoBehaviour, iProjectile
{
    [SerializeField] protected float lifeTime = 10f;
    [SerializeField] protected int damage;
    [SerializeField] protected float speedMovement = 1;
    public float Speed { set => speedMovement = value; }

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
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<DestroyWall>() != null)
            Destroy(gameObject);
    }
}
