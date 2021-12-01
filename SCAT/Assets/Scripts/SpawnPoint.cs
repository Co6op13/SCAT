using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour
{
    [SerializeField] protected bool isActive = false;
    [SerializeField] protected GameObject prefabEnemy;
    [SerializeField] protected Color32 color;
    protected EnemyObjectPooler enemyPooler;
    protected GameObject enemy;


    protected virtual void Awake ()
    {
        enemyPooler = EnemyObjectPooler.Instance;
    }

    protected virtual void MakeSpawn ()
    {
        //enemy = enemyPooler.GetFromPool(prefabEnemy.name, transform.position, transform.rotation);
    }


}
