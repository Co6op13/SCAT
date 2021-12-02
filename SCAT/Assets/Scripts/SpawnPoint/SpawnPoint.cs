using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoint : MonoBehaviour, iActivation
{
    [SerializeField] protected bool isActive = false;
    [SerializeField] protected GameObject prefabEnemy;
    protected GameObject enemy;

    public void ActivationObject()
    {
        MakeSpawn();
    }

    protected virtual void MakeSpawn ()
    {
        Destroy(gameObject);
    }


}
