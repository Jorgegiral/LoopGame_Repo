using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTrigger : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;
    [SerializeField] GameObject player;
    [SerializeField] OrbHealth playerHealth;
    private newEnemy enemy;
    public float enemydamage = 3f;
    private bool isInvincible = false;
    private float invincibilityTime = 1f;


    private void Start()
    {
        EnemyDamageScaling();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<OrbHealth>();

}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsEnemyAttacking() && !isInvincible)
        {
            ApplyDamage();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && IsEnemyAttacking() && !isInvincible)
        {
            ApplyDamage();
        }
    }


    private bool IsEnemyAttacking()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }

    private void ApplyDamage()
    {
        playerHealth.TakeDamage(enemydamage);
        StartCoroutine(InvincibilityCooldown());
    }


    public void EnemyDamageScaling()
    {
        enemydamage = enemydamage + (CoinAndScore.instance.score / 10);
    }
    private IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;  
        yield return new WaitForSeconds(invincibilityTime);  
        isInvincible = false;  
    }
}
