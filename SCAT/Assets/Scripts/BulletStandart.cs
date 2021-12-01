using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandart : BasicBullet
{
    void FixedUpdate()
    {       
        rb2d.velocity = transform.right *  speedMovement;
    }
}
