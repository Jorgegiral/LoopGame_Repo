using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTrigger : MonoBehaviour
{
    private Animator enemyAnimator;
    private GameObject player;
    private OrbHealth playerHealth;
    private newEnemy enemy;
    public float enemydamage = 3f;
    private bool isInvincible = false;
    private float invincibilityTime = 1f;

    private void Start()
    {
        EnemyDamageScaling();
        enemyAnimator = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<OrbHealth>();

}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (IsEnemyAttacking() && !isInvincible)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerHealth.TakeDamage(enemydamage);
                StartCoroutine(InvincibilityCooldown());
            }
        }
    }

    private bool IsEnemyAttacking()
    {
        return enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
    }
    public void EnemyDamageScaling()
    {
        enemydamage = enemydamage + (GameManager.instance.score / 10);
    }
    private IEnumerator InvincibilityCooldown()
    {
        isInvincible = true;  
        yield return new WaitForSeconds(invincibilityTime);  
        isInvincible = false;  
    }
}
