using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private List<Transform> playersTransform;
    private GameObject[] players;

    public void AddPlayer(Transform playerTransform)
    {
        playersTransform.Add(playerTransform);
    }
    public void DeletePlayer(Transform playerTransform)
    {
        playersTransform.Remove(playerTransform);
    }

    public Transform GetNearestTarger(Vector3 selfPosition)
    {
        int nearest = 0;
        if (playersTransform.Count == 1)
            return playersTransform[nearest];
        float distance = 999f;
        
        for (int i = 0; i < playersTransform.Count; i++)
        {
            if (distance > Vector2.Distance(playersTransform[i].position, selfPosition))
            {
                distance = Vector2.Distance(playersTransform[i].position, selfPosition);
                nearest = i;
            }
        }
        Debug.Log(playersTransform[nearest].name);
        return playersTransform[nearest];
    }

}
