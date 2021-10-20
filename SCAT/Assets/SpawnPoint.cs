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
    
    private bool isWait = false;

    public bool IsActive { get => isActive;}

    // Start is called before the first frame update

    public void MakeSpawn()
    {
        pathForEnemy = Instantiate(pathForEnemy, transform.position, transform.rotation);
        GameObject enemy = Instantiate(prefabEnemy, transform.position, transform.rotation);
        SplineWalker script = enemy.GetComponent<SplineWalker>();
        script.Path = pathForEnemy.GetComponent<BezierSpline>();
        script.SpeedMovement = enemySpeed;
        script.ActivationObject();
        enemy.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (amountEnemy > 0)
        {
            if (isActive && !isWait)
            {
                isWait = true;
                MakeSpawn();
                amountEnemy -= 1;
                StartCoroutine(WaitDelay());
            }
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("I'am " + gameObject.name + "off");
        }
    }
    IEnumerator WaitDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        isWait = false;
    }

    public void Activation()
    {
        isActive = true;
    }

    public void ActivationObject()
    {
        isActive = true;
    }
}
