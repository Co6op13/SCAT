using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyWithPath : SpawnPoint
{
    [SerializeField] private GameObject prefabPath;
    [SerializeField] private float enemySpeed;
    private GameObject path;


    protected override void MakeSpawn()
    {
        enemy = EnemyObjectPooler.Instance.GetFromPool(prefabEnemy.name, transform.position, transform.rotation);
        path = PathObjectPooler.Instance.GetFromPool(prefabPath.name, transform.position, transform.rotation);
        SplineWalker script = enemy.GetComponent<SplineWalker>();
        script.Path = path.GetComponent<BezierSpline>();
        script.SpeedMovement = enemySpeed;
        script.ActivationObject();
        base.MakeSpawn();
    }

}
