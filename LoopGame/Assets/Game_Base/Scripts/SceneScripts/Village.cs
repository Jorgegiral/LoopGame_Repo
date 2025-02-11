using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    private Transform player;
    public Transform rightSpawn;
    public Transform leftSpawn;

    private void Awake()
    {
        GameManager.instance.levelCompleted = false;
        GameManager.instance.enemycount = 0;
        GameManager.instance.bosskilled = false;

        player = GameObject.FindWithTag("Player").transform;
        if (GameManager.instance.spawnRight)
        {
            player.transform.position = rightSpawn.position;
        }
        else
        {
            player.transform.position = leftSpawn.position;
        }
    }
}
