using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class ChaseEnemy : MonoBehaviour
{
    public Transform player;
    public float attackCD = 3f;
    private float nextAttack;
    [SerializeField] Rigidbody2D enemyRb;
    [SerializeField] Animator enemyAnim;
    private bool isFacingRight;
    public float lineOfSite = 5f;
    private bool playerInCollider;
    private float cooldownTimer = Mathf.Infinity;
    [Header("Stats Parameters")]
    public float enemyspeed = 2f;
    private bool isAttacking = false;
    private bool followingEnemy  = false;

    void Start()
    {
        ScaleSystem();
        GameManager.instance.enemycount += 1;
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        cooldownTimer += Time.deltaTime;
        FacePlayer();
        if (playerInCollider)
        {
            if (cooldownTimer >= attackCD)
            {
                cooldownTimer = 0;
                isAttacking = true;
                enemyAnim.SetTrigger("Attack");
                StartCoroutine(ResetAttack());
            }
        }
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer < lineOfSite)
        {
            followingEnemy = true;
            Vector2 targetCorrected = new Vector2(player.position.x, transform.position.y);

            Vector2 direction = (targetCorrected - (Vector2)transform.position).normalized;

            enemyRb.velocity = new Vector2(direction.x * enemyspeed, enemyRb.velocity.y);
        }
        else
        {
            followingEnemy = false;

        }
    }
    private void Update()
    {
        HandleAnimations();

    }
    void HandleAnimations()
    {

        enemyAnim.SetBool("isWalking", followingEnemy);
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight;
    }

    void FacePlayer()
    {
        float directionToPlayer = transform.position.x - player.transform.position.x;
        bool playerIsRight = directionToPlayer > 0;

        if ((playerIsRight && !isFacingRight) || (!playerIsRight && isFacingRight))
        {
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(enemyAnim.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false;
    }
    void ScaleSystem()
    {
        EnemyAttackCDScaling();
        EnemySpeedScaling();
    }

    public void EnemyAttackCDScaling()
    {
        attackCD = attackCD - (CoinAndScore.instance.score / 100);
    }
    public void EnemySpeedScaling()
    {
        enemyspeed = enemyspeed + (CoinAndScore.instance.score / 100);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
