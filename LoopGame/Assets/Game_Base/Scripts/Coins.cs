using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private int numRandom;
    void OnTriggerEnter2D(Collider2D other)
    {
        numRandom = Random.Range(1, 3);
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoins(numRandom);
            Destroy(gameObject);

        }
    }
}
