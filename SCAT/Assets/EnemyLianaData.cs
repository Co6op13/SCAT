using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLianaData : MonoBehaviour,iHP
{
    [SerializeField] internal Transform head;
    [SerializeField] private int maxHP;
    [SerializeField] internal float lianaLength;
    [SerializeField] internal float speedMovemeth;
    [SerializeField] internal Transform[] playersTransform;   
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
            var direction = (playersTransform[0].position - head.transform.position).normalized;
            var dir = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            head.transform.eulerAngles = new Vector3(0f, 0f, dir);
            head.transform.position = Vector3.MoveTowards(head.position, transform.position +  direction * lianaLength 
            , speedMovemeth * Time.fixedDeltaTime);
    }

}
