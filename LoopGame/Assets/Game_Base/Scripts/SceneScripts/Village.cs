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

        GameManager.instance.AddCoins(0);
        GameManager.instance.levelCompleted = false;
        GameManager.instance.enemycount = 0;
        GameManager.instance.bosskilled = false;
        player = GameObject.FindWithTag("Player").transform;

        if (GameManager.instance.score == 0)
        {
            player.transform.position = fuente.position;
        }else
        if (GameManager.instance.spawnRight && GameManager.instance.score>0)
        {
            player.transform.position = rightSpawn.position;
        }
        else
        {
            player.transform.position = leftSpawn.position;
        }
    }
}
