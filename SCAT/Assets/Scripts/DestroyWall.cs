using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DestroyWall : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;

    private void Start()
    {
        transform.localScale = localScale;
    }


    //private void OnTriggerExit2D(Collider2D collision)
    //{        
    //    Debug.Log("coll");
    //    Destroy(collision.gameObject);
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, localScale);
    }

}
