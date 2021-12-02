using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPooler : ObjectPooler
{
    #region Singleton
    public static EnemyObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
