using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class EnemyLianaData : MonoBehaviour,iHP
{
    [SerializeField] internal Transform head;
    [SerializeField] private int maxHP;
    [SerializeField] internal float lianaLength;
    [SerializeField] internal float speedMovemeth;
    [SerializeField] internal Transform[] playersTransform;
    [SerializeField, Range( 1, 5)] private float offset;
    private Vector3 target = Vector3.zero;
    private Vector3[] segmentVelocity;
    private float direxctionX; // if player to the left -1 else +1
    private float direxctionY; // if player to the apper 1 else +1
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playersTransform = new Transform[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playersTransform[i] = players[i].transform;
        }
    }

    public int GetMaxHP()
    {
        return (maxHP);
    }


    private void FixedUpdate()
    {
        // Debug.Log(head.transform.localPosition);
        //Debug.Log("p " + transform.TransformDirection(playersTransform[0].position));
        // var t = (playersTransform[0].position);
        Vector3 directionToTarget = (playersTransform[0].position - transform.position).normalized;
        Debug.DrawRay(transform.position, directionToTarget * lianaLength, Color.red);
        float directionAngle = GetAngleFromVectorFloat(directionToTarget);
        float catetA = playersTransform[0].position.y - transform.localPosition.y;
        if (transform.position.x > playersTransform[0].position.x)
            direxctionX = 1;
        else
            direxctionX = -1;
        if (transform.position.y - lianaLength  > playersTransform[0].position.y )
            direxctionY = -1;
        else
            direxctionY = 1;

        if (catetA * catetA > lianaLength * lianaLength - lianaLength)
            //{
            catetA = lianaLength + directionToTarget.x * offset * direxctionX;
            Debug.Log(gameObject.name + " " + catetA);
            float catetB = Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);            

            target = new Vector3(transform.localPosition.x - (catetB * direxctionX),
                                 transform.position.y - catetA * direxctionY, 0f);//new Vector3(transform.position.x + catetB, transform.position.y + catetA, 0f);
            Debug.DrawLine(transform.position, target, Color.yellow);
            MoveHead(target, directionAngle);
        //}
        //else
        //{
        //    target = new Vector3(directionToTarget.x * offset, lianaLength - 1f, 0f);
        //    Debug.Log("-------" + target);
        //    Debug.DrawLine(transform.position, target + transform.position, Color.green);
        //    MoveHead(target + transform.localPosition, directionAngle);
        //}
    }

    //private void FixedUpdate()
    //{
    //   // Debug.Log(head.transform.localPosition);
    //    //Debug.Log("p " + transform.TransformDirection(playersTransform[0].position));
    //   // var t = (playersTransform[0].position);
    //    Vector3 directionToTarget = (playersTransform[0].position - transform.position).normalized;
    //    Debug.DrawRay(transform.position,directionToTarget * lianaLength, Color.red);
    //    float directionAngle = GetAngleFromVectorFloat(directionToTarget);
    //    float catetA = playersTransform[0].position.y - transform.localPosition.y;
    //    if (catetA * catetA < lianaLength * lianaLength - lianaLength )
    //    {
    //        //catetA = directionToTarget.x * offset;
    //        Debug.Log(gameObject.name + " " + catetA);
    //        float catetB = Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);

    //        if (transform.position.x > playersTransform[0].position.x)
    //            direxctionX = 1;
    //        else
    //            direxctionX = -1;

    //        target = new Vector3(transform.localPosition.x - (catetB * direxctionX), transform.localPosition.y + catetA, 0f);//new Vector3(transform.position.x + catetB, transform.position.y + catetA, 0f);
    //        Debug.DrawLine(transform.position, target, Color.yellow);
    //        MoveHead(target, directionAngle);
    //    }
    //    else
    //    {
    //        target = new Vector3(directionToTarget.x * offset, lianaLength - 1f, 0f);
    //        Debug.Log("-------" + target);
    //        Debug.DrawLine(transform.position, target + transform.position, Color.green);
    //        MoveHead(target + transform.localPosition, directionAngle);
    //    }
    //}

    //

    //private void FixedUpdate()
    //{
    //    var directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;
    //    float directionAngle = GetAngleFromVectorFloat(directionToPlayer);
    //  //  Debug.Log(directionAngle);
    //    //if (Mathf.Abs(playersTransform[0].position.y - transform.position.y) < lianaLength)
    //    //{
    //    float catetA = playersTransform[0].position.y - transform.position.y;
    //    if (catetA < 0 )
    //        catetA *= -1;
    //    float catetB;
    //    if (catetA < lianaLength)
    //    {
    //        catetB = Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);
    //    }
    //    else
    //    {
    //        catetB = Mathf.Sqrt(catetA * catetA - lianaLength * lianaLength);
    //    }
    //    // target = new Vector3( transform.position.x + catetB, transform.position.y + catetA, 0f);
    //    //Debug.Log(catetA);
    //    if (transform.position.x > playersTransform[0].position.x)
    //    {
    //        MoveHead(new Vector3(transform.position.x - catetB, transform.position.y + catetA, 0f),
    //            directionAngle);
    //    }
    //    else
    //    {
    //        MoveHead(new Vector3(transform.position.x + catetB, transform.position.y + catetA, 0f),
    //            directionAngle);
    //    }
    //head.transform.position = target;
    //   } 
    //else
    //{

    //    if (directionAngle < 60)
    //    {
    //        target = GetVectorFromAngle(70);
    //    }
    //    else if (directionAngle > 140)
    //    {
    //        target = GetVectorFromAngle(130);
    //    }
    //    else target = Vector3.up;
    //    //target = ;

    //    // target = transform.position + GetVectorFromAngle((int)(directionAngle / 2f)) * lianaLength;
    //    //MoveHead(target, directionAngle);
    //    MoveHead(transform.position + directionToPlayer * lianaLength, directionAngle);
    //    //var directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;

    // }



    //}private void FixedUpdate()
    //{
    //    var directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;
    //    var directionAngle = GetAngleFromVectorFloat(directionToPlayer);// Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    Debug.Log(directionAngle);
    //    if (directionAngle > 40 & directionAngle < 130)
    //    {
    //        MoveHead(directionToPlayer, directionAngle);
    //    }
    //    else if (directionAngle < 40)
    //    {
    //        var direction = GetVectorFromAngle(40);
    //        MoveHead(direction, directionAngle);
    //        //direction = new Vector3(  playersTransform[0].position.y - head.transform.position.y
    //    } 
    //    else if (directionAngle > 130)
    //    {
    //        directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;
    //        //var direction = GetVectorFromAngle(130);
    //        MoveHead(direction, directionAngle);
    //    }
    //}

    private void MoveHead(Vector3 moveDirection, float directionAngle)
    {
        head.transform.eulerAngles = new Vector3(0f, 0f, directionAngle);
        head.transform.position = Vector3.MoveTowards(head.position, moveDirection
        , speedMovemeth * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(target , 1f);
    }

    public static Vector3 GetVectorFromAngle(int angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

}
