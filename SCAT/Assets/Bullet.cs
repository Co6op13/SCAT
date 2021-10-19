using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    private int damage;

    public float Speed {set => speed = value; }
    public int Damage {set => damage = value; }

    void FixedUpdate()
    {       
        transform.Translate( Vector3.right * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        Debug.Log(collision.name);
    }
}
