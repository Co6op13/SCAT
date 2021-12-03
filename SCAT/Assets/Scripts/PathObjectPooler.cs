using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObjectPooler : ObjectPooler
{
    #region Singleton
    public static PathObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
