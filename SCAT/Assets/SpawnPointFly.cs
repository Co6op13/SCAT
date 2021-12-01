using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointFly : SpawnPoint, iActivation
{
    [SerializeField] private GameObject pathForEnemy;
    [SerializeField] private float enemySpeed;
    private BezierObjectPooler pathPooler;
    private BulletsObjectPooler pool;

    protected override void Awake()
    {
        pathPooler = BezierObjectPooler.Instance;
        pool = BulletsObjectPooler.Instance;
        base.Awake();
    }
    protected override void MakeSpawn()
    {
        Debug.Log("test");
        enemy = pool.GetFromPool(prefabEnemy.name, transform.position, transform.rotation);
        enemy.SetActive(true);
        Debug.Log(enemy.name);
        //SplineWalker script = enemy.GetComponent<SplineWalker>();
        //script.Path = pathForEnemy.GetComponent<BezierSpline>();
        //script.SpeedMovement = enemySpeed;
    }
    public void ActivationObject()
    {
        MakeSpawn();
    }
    protected void OnDrawGizmos()
    {
        Gizmos.color = color;
        Gizmos.DrawSphere(transform.position, 1f);
        //    Gizmos.color = color;
        //    Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
