using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArea : MonoBehaviour
{





    [SerializeField] private Vector3 activlocalScale;
    [SerializeField] private Vector3 deactivlocalScale;
    private void Start()
    {
        //transform.localScale = ActivlocalScale;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Destroy(collider.gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Try activation from triget " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<iActivation>() != null)
        {
            collision.gameObject.GetComponent<iActivation>().ActivationObject();
        }
    }
    //   private void OnCollisionExit2D(Collision2D collision)
    //{
    //	Debug.Log("coll");
    //	Destroy(collision.gameObject);
    //}
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, activlocalScale);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, deactivlocalScale);
    }
}
