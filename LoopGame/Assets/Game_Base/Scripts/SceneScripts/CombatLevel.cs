using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLevel : MonoBehaviour
{
    private Transform player;
    public GameObject rightSpawn;
    public GameObject leftSpawn;


    private void Awake()
    {

        GameManager.instance.levelCompleted = false;
        GameManager.instance.AddCoins(0);
        GameManager.instance.AddScore(0);
        player = GameObject.FindWithTag("Player").transform;
        if (GameManager.instance.spawnRight)
        {
            player.transform.position = rightSpawn.transform.position;
        }
        else
        {
            player.transform.position = leftSpawn.transform.position;
        }
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        if (GameManager.instance.spawnRight)
        {
            player.transform.position = rightSpawn.transform.position;
        }
        else
        {
            player.transform.position = leftSpawn.transform.position;
        }
    }
    private void Update()
    {
        if (GameManager.instance.enemycount <= 6)
        {
            GameManager.instance.levelCompleted = true;
        }

    }
}
