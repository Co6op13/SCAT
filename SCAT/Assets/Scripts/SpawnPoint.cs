using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour, iActivation
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private GameObject prefabEnemy;
    [SerializeField] private GameObject pathForEnemy;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int amountEnemy;
    [SerializeField] private float timeDelay;
    [SerializeField] private Transform parantObject;
    
    public bool IsActive { get => isActive;}


    private void Start()
    {
        parantObject = transform.parent;
        pathForEnemy = Instantiate(pathForEnemy, transform.position, transform.rotation);
        pathForEnemy.transform.SetParent(parantObject);
    }

    public void MakeSpawn()
    {
        GameObject enemy = Instantiate(prefabEnemy, transform.position, transform.rotation);
        enemy.transform.SetParent(parantObject);
        SplineWalker script = enemy.GetComponent<SplineWalker>();
        script.Path = pathForEnemy.GetComponent<BezierSpline>();
        script.SpeedMovement = enemySpeed;
        script.ActivationObject();
        enemy.SetActive(true);
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < amountEnemy; i++)
        {
            MakeSpawn();
            yield return new WaitForSeconds(timeDelay);
        }
        Destroy(gameObject);
        yield break;
    }
   

    public void ActivationObject()
    {
        StartCoroutine(Spawn());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1f);
    }

}
