using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RestLevel : MonoBehaviour
{

    private Transform player;
    public Transform rightSpawn;
    public Transform leftSpawn;

    private void Awake()
    {
        CoinAndScore.instance.AddCoins(0);
        CoinAndScore.instance.AddScore(0);
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
