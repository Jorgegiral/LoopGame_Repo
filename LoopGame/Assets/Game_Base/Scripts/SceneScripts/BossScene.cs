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
        GameManager.instance.AddCoins(0);
        GameManager.instance.AddScore(0);
        player = GameObject.FindWithTag("Player").transform;
        if (GameManager.instance.spawnRight)
        {
            player.transform.position = leftSpawn.position;
        }
        else
        {
            player.transform.position = rightSpawn.position;
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
