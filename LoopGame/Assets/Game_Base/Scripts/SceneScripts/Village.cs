using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    private Transform player;
    [SerializeField] Transform rightSpawn;
    [SerializeField] Transform leftSpawn;
    [SerializeField] Transform fuente;

    private void Awake()
    {
        GameManager.instance.inShop = false;

        GameManager.instance.itemsRemain = 0;
        CoinAndScore.instance.AddCoins(0);
        CoinAndScore.instance.AddScore(0);
        GameManager.instance.levelCompleted = false;
        GameManager.instance.enemycount = 0;
        GameManager.instance.bosskilled = false;
        player = GameObject.FindWithTag("Player").transform;

        if (CoinAndScore.instance.score == 0)
        {
            player.transform.position = fuente.position;
        }else
        if (GameManager.instance.spawnRight && CoinAndScore.instance.score>0)
        {
            player.transform.position = rightSpawn.position;
        }
        else
        {
            player.transform.position = leftSpawn.position;
        }
    }
}
