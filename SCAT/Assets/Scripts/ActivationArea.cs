using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ActivationArea : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;
    private void Start()
    {
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.gameObject.GetComponent<iActivation>() != null)
        {
            collision.gameObject.GetComponent<iActivation>().ActivationObject();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, localScale);
    }

}
