using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBullet : MonoBehaviour
{
    [SerializeField] private float speedRotate;
    private float nextAngle;
    void Start()
    {
        
        nextAngle = 45;
    }

    void FixedUpdate()
    {
        Debug.Log("«¿¡€À ƒÀﬂ ◊≈√Œ œ»—¿À ›“Œ“ — –»œ“. ŒÕ Õ¿’Œƒ»“—ﬂ Õ¿ " + gameObject.name);
        Debug.Log(transform.eulerAngles.z + "   " + nextAngle);
        if (transform.eulerAngles.z == nextAngle )
        {
            Debug.Log("test");
            nextAngle = nextAngle * 2;
        }
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
           Quaternion.Euler(0f, 0f, nextAngle), speedRotate * Time.fixedDeltaTime);
    }
}
