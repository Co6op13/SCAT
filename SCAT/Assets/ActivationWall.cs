using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationWall : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;

    private void Start()
    {
        transform.localScale = localScale;
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("coll");
       // Destroy(collision.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, localScale);
    }

}
