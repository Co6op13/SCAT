using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersPool : MonoBehaviour
{
    [SerializeField] private Transform[] playersTransform;

    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        playersTransform = new Transform[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            playersTransform[i] = players[i].transform;
        }
    }


    public Transform GetNearestTarger(Vector3 selfPosition)
    {
        int nearest = 0;
        if (playersTransform.Length == 1)
            return playersTransform[nearest];
        float distance = 999f;

        for (int i = 0; i < playersTransform.Length; i++)
        {
            if (distance > Vector2.Distance(playersTransform[i].position, selfPosition))
            {
                distance = Vector2.Distance(playersTransform[i].position, selfPosition);
                nearest = i;
            }
        }
        return playersTransform[nearest];
    }
}
