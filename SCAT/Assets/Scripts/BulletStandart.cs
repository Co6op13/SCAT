using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandart : BasicBullet
{
    void FixedUpdate()
    {       
        transform.Translate( Vector3.right * speedMovement * Time.fixedDeltaTime);
        if (Time.time > lifeTime)
        {
            Destroy(gameObject);
        }
    }

}
