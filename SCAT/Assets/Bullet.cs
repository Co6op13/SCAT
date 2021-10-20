using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour,iProjectile
{
    [SerializeField] private float lifeTime = 10f;
    [SerializeField] private float speed = 1;
    [SerializeField] private int damage;
    [SerializeField] private float currentTime;

    public float Speed {set => speed = value; }
  
    private void Start()
    {
        lifeTime = Time.time + lifeTime;
    }

    void FixedUpdate()
    {       
        transform.Translate( Vector3.right * speed * Time.deltaTime);
        if (Time.time > lifeTime)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.GetComponent<HP>() != null)
        {
            Debug.Log("hit in "+ collision.name);
            collision.gameObject.GetComponent<HP>().GetDamage(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<DestroyWall>() != null)
            Destroy(gameObject);
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
}
