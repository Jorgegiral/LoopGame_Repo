using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private Animator playerAnimator;
    private bool isInvincible = false; 
    private float invincibilityTime = 1f; 
    public float damage = 5f;
    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();  // Asumiendo que el jugador tiene el tag "Player"

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsPlayerAttacking()&& !isInvincible)
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
        StartCoroutine(InvincibilityCooldown());
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsPlayerAttacking() && !isInvincible)
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
        StartCoroutine(InvincibilityCooldown());

    }

    private bool IsPlayerAttacking()
    {
        return playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Attack");
    }
    private IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;  
        yield return new WaitForSeconds(invincibilityTime);  
        isInvincible = false;  
    }
}