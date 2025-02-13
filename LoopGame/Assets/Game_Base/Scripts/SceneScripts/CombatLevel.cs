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
        CoinAndScore.instance.AddCoins(0);
        CoinAndScore.instance.AddScore(0);
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
        if (GameManager.instance.enemycount <= 3)
        {
            GameManager.instance.levelCompleted = true;
        }

    }
}
