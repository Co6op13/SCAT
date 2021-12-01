using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class DestroyWall : MonoBehaviour
{
    [SerializeField] private Vector3 localScale;

    private void Start()
    {
        Debug.Log(gameObject.layer);
        transform.localScale = localScale;
    }


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("test");
    //    Debug.Log("coll");
    //    Destroy(collision.gameObject);
    //}

    void OnTriggerExit2D(Collider2D collision)
    {
        //Get the items layer name
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        //If it is an enemy...
        if (layerName == "Enemy")
            //...deactivate it (since enemies aren't a part of the generic pool)...
            collision.gameObject.SetActive(false);
        //...otherwise...
        else
            Destroy(collision.gameObject);
            //...send it to the pool.
        //    ObjectPool.current.PoolObject(c.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, localScale);
    }

}
