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
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;
    private float hitForce;

    [SerializeField] Animator enemyAnim;

    private bool isFacingRight = true;
    private bool playerInCollider = false;
    [SerializeField] HitboxTrigger hitbox;
    [SerializeField] HitboxTriggerPlayer playerhitbox;
    [SerializeField] OrbHealth playerHealth;
    private float distanceToPlayer;

    [Header("Stats Parameters")]
    public float enemydamage = 3f;
    public float enemymaxhealth = 10f;
    public float enemycurrenthealth;
    public float enemyspeed = 2f;

    [SerializeField] public float attackCD = 3.0f;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        ScaleSystem();
        enemycurrenthealth = enemymaxhealth;    
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        playerhitbox = player.GetComponent<HitboxTriggerPlayer>();
        playerHealth = player.GetComponent<OrbHealth>();
        playerRb = player.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        cooldownTimer += Time.deltaTime;
        if (hitbox.isPlayerinCollision)
        {
            if (cooldownTimer >= attackCD)
            {
                cooldownTimer = 0;
                enemyAnim.SetTrigger("Attack");
            }
        }
        if (playerInCollider )
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
    private void Move()
    {
        Debug.Log("Im moving");
        Vector2 targetPosition = isFacingRight ? rightLimit.position : leftLimit.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, enemyspeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.3f)
        {
            Flip();
        }
    }
    private void ChasePlayer()
    {
        Debug.Log("Im chasing");

        if (playerInCollider)
        {
            FacePlayer();
            float direction = (player.transform.position.x > transform.position.x) ? 1 : -1;
            enemyRb.velocity = new Vector2(direction * enemyspeed, enemyRb.velocity.y);
        }
    }
    public void DamagePlayer()
    {
        if (hitbox.isPlayerinCollision)
            playerHealth.TakeDamage(enemydamage);
            Vector2 hit = (transform.position - player.transform.position).normalized;
            playerRb.velocity = Vector2.zero;
            playerRb.AddForce(new Vector2(hit.x * hitForce, Mathf.Abs(hitForce * 0.5f)), ForceMode2D.Impulse);

        }
    public void TakeDamage()
    {
        if (playerhitbox.isEnemyinCollision)
        {
            enemycurrenthealth -= PlayerManager.instance.playerDamage;
        }
    }

    void ScaleSystem()
    {
        EnemyDamageScaling();
        EnemyHealScaling();
        EnemyAttackCDScaling();
        EnemySpeedScaling();
    }
    public void EnemyDamageScaling()
    {
        
    }
    public void EnemyHealScaling()
    {

    }
    public void EnemyAttackCDScaling()
    {

    }
    public void EnemySpeedScaling()
    {

    }
}




