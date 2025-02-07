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
    private void Start()
    {
        enemyAnim.Play("EnemyIdle");
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
            Flip();
        }
    }
    private IEnumerator FlipAfterDelay(float delay)
    {
        Flip();
        enemyAnim.SetBool("isWalking", false); 
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
            enemyAnim.SetBool("isWalking", true);
            float distanceToPlayer = player.transform.position.x - transform.position.x;
            float direction = (player.transform.position.x > transform.position.x) ? 1 : -1;
            enemyRb.velocity = new Vector2(direction * moveSpeed, enemyRb.velocity.y);
            if (hitbox.isPlayerinCollision && canAttack)
            {
                canAttack = false;
                attackCD = 3.0f;
                enemyAnim.SetBool("isWalking", false);
            //    Vector2 hit = (transform.position - player.transform.position).normalized;
            //    enemyRb.AddForce(new Vector2(hit.x * hitForce, Mathf.Abs(hitForce * 0.5f)), ForceMode2D.Impulse);
                enemyAnim.SetBool("Attack", true);
                playerHealth.TakeDamage(0.2f);
                

            }

        }
    }
    public void AttackCD()
    {
        if (!canAttack)
        {
            enemyAnim.SetBool("Attack", false);

            attackCD -= Time.deltaTime;
            if (attackCD <= 0)
            {
                canAttack = true;

            }
        }
    }

}
