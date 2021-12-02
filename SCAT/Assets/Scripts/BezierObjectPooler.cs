using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierObjectPooler : ObjectPooler
{
    #region Singleton
    public static BezierObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}