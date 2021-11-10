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

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Try activation from triget " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<iActivation>() != null)
        {
            collision.gameObject.GetComponent<iActivation>().ActivationObject();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Try activation from collision " + collision.gameObject.name);
    //    if (collision.gameObject.GetComponent<iActivation>() != null)
    //    {
    //        collision.gameObject.GetComponent<iActivation>().ActivationObject();
    //    }
    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, localScale);
    }

}
