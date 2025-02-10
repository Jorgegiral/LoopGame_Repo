using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private Animator playerAnimator;
    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();  // Asumiendo que el jugador tiene el tag "Player"

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerAttacking())
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<FloatingHP>().TakeDamage(PlayerManager.instance.playerDamage);
            }
            if (collision.gameObject.CompareTag("Boss"))
            {
                collision.gameObject.GetComponent<BossHP>().TakeDamage(PlayerManager.instance.playerDamage);
            }
        }
    }

    private bool IsPlayerAttacking()
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack");
    }
}