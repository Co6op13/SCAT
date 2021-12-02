using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStaticEnemy : SpawnPoint
{
    protected override void MakeSpawn()
    {
        enemy = EnemyObjectPooler.Instance.GetFromPool(prefabEnemy.name, transform.position, transform.rotation);
        base.MakeSpawn();
    }
}
