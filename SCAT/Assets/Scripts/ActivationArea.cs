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

        if (collision.gameObject.GetComponents<iActivation>() != null)
        {
            var interfaces = collision.gameObject.GetComponents<iActivation>();
            foreach(var i in interfaces)
            {
                i.ActivationObject();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, localScale);
    }

}
