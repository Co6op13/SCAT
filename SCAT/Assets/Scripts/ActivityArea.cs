using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ActivityArea : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;
    private void Start()
    {
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.GetComponents<iActivation>() != null)
        {
            var interfaces = collision.gameObject.GetComponents<iActivation>();
            foreach(var i in interfaces)
            {
                i.ActivationObject();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        collision.gameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, localScale);
    }

}
