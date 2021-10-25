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
    [SerializeField] private Vector3 offset;
    private Vector3 target = Vector3.zero;
    private Vector3[] segmentVelocity;

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
        var directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;
        var directionAngle = GetAngleFromVectorFloat(directionToPlayer);
        Debug.Log (directionAngle);
        if (Mathf.Abs(playersTransform[0].position.y - transform.position.y) < lianaLength)
        {
            float catetA = playersTransform[0].position.y - transform.position.y;
            float catetB =Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);
           // target = new Vector3( transform.position.x + catetB, transform.position.y + catetA, 0f);
            //Debug.Log(target);            
            if (transform.position.x > playersTransform[0].position.x)
            {
                MoveHead(new Vector3(transform.position.x - catetB, transform.position.y + catetA, 0f), 
                    directionAngle);
            }
            else
            {
                MoveHead(new Vector3(transform.position.x + catetB, transform.position.y + catetA, 0f),
                    directionAngle);
            }
            //head.transform.position = target;
        } 
        else
        {

            if (directionAngle < 50)
            {
                target = GetVectorFromAngle(50);
            }
            else if (directionAngle > 130)
            {
                target = GetVectorFromAngle(130);
            }
            else target = Vector3.up;
           
            target = transform.position + target * lianaLength;
            MoveHead(target, directionAngle);
            //var directionToPlayer = (playersTransform[0].position - head.transform.position).normalized;

        }
        

    }
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
