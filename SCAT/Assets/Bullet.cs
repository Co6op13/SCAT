using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D collider2D;
    private int damage;

    public float Speed {set => speed = value; }
    public int Damage {set => damage = value; }

    private void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
       // boxCollider2D = GetComponent<BoxCollider2D>();
       // rigidbody2D = GetComponent<Rigidbody2D>();
       // rigidbody2D.velocity = transform.right * speed;
    }

    void FixedUpdate()
    {
        
       // transform.Translate( Vector3.right * speed * Time.deltaTime);
       // transform.Translate( Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
  //  private void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("test1");
        Debug.Log(collision.name);
    }

    

}
