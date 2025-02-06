using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private Enemy_behavior enemyinstance;
    private void Awake()
    {
        enemyinstance = GetComponentInParent<Enemy_behavior>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyinstance.target = collision.transform;
            enemyinstance.inRange = true;
            enemyinstance.hotZone.SetActive(true);
        }
    }
}
