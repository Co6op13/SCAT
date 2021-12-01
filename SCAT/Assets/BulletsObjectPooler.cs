using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsObjectPooler : ObjectPooler
{
    #region Singleton
    public static BulletsObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion
}
