using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSpawn : MonoBehaviour
{
    [SerializeField] Transform limiteright;
    [SerializeField] Transform limiteleft;
    [SerializeField] OrbHealth playerHealth;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<OrbHealth>();


    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {

            if (GameManager.instance.spawnRight) { 
            player.gameObject.transform.position =limiteright.position;
            }
            else { player.gameObject.transform.position =limiteleft.position;}

        playerHealth.TakeDamage(2);
        }
    }

