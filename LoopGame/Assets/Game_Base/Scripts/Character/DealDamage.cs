using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<FloatingHP>().TakeDamage(PlayerManager.instance.playerDamage);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<BossHP>().TakeDamage(PlayerManager.instance.playerDamage);
        }
        gameObject.SetActive(false);
    }
    public void ActivateHitbox()
    {
        gameObject.SetActive(true) ;
    }
}