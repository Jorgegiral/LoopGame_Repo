using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class newEnemy : MonoBehaviour
{
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private Rigidbody2D enemyRb;
    public Collider2D CapsuleRb;
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] Animator enemyAnim;
    private bool canAttack =  true;
    [SerializeField] public float attackCD = 3.0f;
    public float attackrange;
    private bool isFacingRight = true;
    private bool playerInCollider = false;
    [SerializeField] HitboxTrigger hitbox;
    [SerializeField] OrbHealth playerHealth;
    public float hitForce;

    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerInCollider)
        {
            ChasePlayer();
        }
        else
        {
            Move();
        }
    }
    private void Update()
    {
        AttackCD();
        HandleAnimations();
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
        float directionToPlayer = player.transform.position.x - transform.position.x;
        bool playerIsRight = directionToPlayer > 0;

        if (playerIsRight != isFacingRight)
        {
            Flip();
        }
    }

    void HandleAnimations()
    {
        enemyAnim.SetBool("Attack", !canAttack);
        enemyAnim.SetBool("isWalking", Mathf.Abs(transform.position.x) > 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = false;
        }
    }
    private IEnumerator FlipAfterDelay(float delay)
    {
        Flip();
        yield return new WaitForSeconds(delay); 
        
    }
    private void Move()
    {
        
        Vector2 targetPosition = isFacingRight ? rightLimit.position : leftLimit.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            Flip();
        }
    }
    private void ChasePlayer()
    {
        if (playerInCollider)
        {
            FacePlayer();
            float distanceToPlayer = player.transform.position.x - transform.position.x;
            float direction = (player.transform.position.x > transform.position.x) ? 1 : -1;
            enemyRb.velocity = new Vector2(direction * moveSpeed, enemyRb.velocity.y);

            if (hitbox.isPlayerinCollision && canAttack)
            {
                canAttack = false;
                attackCD = 3.0f;
                playerHealth.TakeDamage(0.2f);
                //    Vector2 hit = (transform.position - player.transform.position).normalized;
                //    enemyRb.AddForce(new Vector2(hit.x * hitForce, Mathf.Abs(hitForce * 0.5f)), ForceMode2D.Impulse);
            }
        }
    }
    public void AttackCD()
    {
        if (!canAttack)
        {
            attackCD -= Time.deltaTime;
            if (attackCD <= 0)
            {
                canAttack = true;
            }
        }
    }

}
