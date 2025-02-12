using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene : MonoBehaviour
{
    private Transform player;
    public Transform rightSpawn;
    public Transform leftSpawn;

    private void Awake()
    {

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
    private void Update()
    {
        if (GameManager.instance.bosskilled)
        {
            GameManager.instance.levelCompleted = true;
        }
    }
}
