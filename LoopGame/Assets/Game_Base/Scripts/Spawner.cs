using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    int numRandom;
    [SerializeField] GameObject rangedEnemy;
    [SerializeField] GameObject chaseEnemy;
    void Start()
    {
        numRandom = Random.Range(0, 2);
        if (numRandom == 0)
        {
            Instantiate(chaseEnemy, gameObject.transform.position, Quaternion.identity);

        }
        else if (numRandom == 1)
        {
            Instantiate(rangedEnemy, gameObject.transform.position, Quaternion.identity);

        }


    }
}
