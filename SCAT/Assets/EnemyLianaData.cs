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

    [Space(5)]
    private Vector3 targetDirection;
    private float targetDirectionAngle;
    private Vector3 movePosition;
    private Vector3 target = Vector3.zero;
    private Vector3[] segmentVelocity;
    private float direxctionX; // if player to the left -1 else +1
    private float direxctionY; // if player to the apper 1 else +1
    private GameObject[] players;

    private void Awake()
    {
        players  = GameObject.FindGameObjectsWithTag("Player");
    }
    private void Start()
    {
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
        Transform nearestTarget = GetNearestTarger();
        targetDirection = (nearestTarget.position - transform.position).normalized;
        targetDirectionAngle = GetAngleFromVectorFloat(targetDirection);
        movePosition = GetMovePostiion(targetDirection, nearestTarget.position);
        MoveHead( movePosition, targetDirectionAngle);
    }

    private Transform GetNearestTarger()
    {
        int nearest = 0;
        if (playersTransform.Length == 1)
            return playersTransform[nearest];
        float distance = 999f;
        
        for ( int i = 0; i < playersTransform.Length; i++ )
        {
            if (distance > Vector2.Distance(playersTransform[i].position,transform.position))
            {
                distance = Vector2.Distance(playersTransform[i].position, transform.position);
                nearest = i;
            }
        }
        return  playersTransform[nearest];
    }

    private Vector3 GetMovePostiion( Vector3 directionToTarget ,  Vector3 playerPosition)
    {

        if (transform.position.x > playerPosition.x)
            direxctionX = -1;
        else
            direxctionX = +1;

        float catetA = playerPosition.y - transform.position.y;

        if (Mathf.Abs(catetA) > lianaLength - 1)                
            catetA = lianaLength - directionToTarget.x * direxctionX;

        float catetB = Mathf.Sqrt(lianaLength * lianaLength - catetA * catetA);

        target = new Vector3((catetB * direxctionX), catetA, 0f);

        if (transform.position.y - lianaLength + 1 > playerPosition.y)
            target = new Vector3(target.x, target.y * -1, 0f);

        Debug.DrawLine(transform.position, target + transform.position, Color.yellow);

        return (target + transform.position);
        
    }
    private void MoveHead(Vector3 moveDirection, float directionAngle)
    {
        head.transform.eulerAngles = new Vector3(0f, 0f, directionAngle);
        head.transform.position = Vector3.MoveTowards(head.position, moveDirection
        , speedMovemeth * Time.fixedDeltaTime);
    }

   
    public static Vector3 GetVectorFromAngle(int angle)
    {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 direction)
    {
        direction = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;

        return angle;
    }

}
