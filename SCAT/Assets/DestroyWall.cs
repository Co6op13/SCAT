using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;

    private void Start()
    {
        transform.localScale = localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        
        Destroy(collision);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, localScale);
    }

}
