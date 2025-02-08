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
    [SerializeField] Animator enemyAnim;

    private bool isFacingRight = true;
    private bool playerInCollider = false;
    [SerializeField] HitboxTrigger hitbox;
    [SerializeField] OrbHealth playerHealth;
    private float distanceToPlayer;
    private float enemydamage;
    private float moveSpeed;
    private bool chasing = false;
    [Header("Attack Parameters")]
    private bool canAttack =  true;
    private bool isAttacking = true;
    [SerializeField] public float attackCD = 3.0f;
    public float attackrange;


    private void Awake()
    {
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player"); 
        playerHealth = player.GetComponent<OrbHealth>();
        enemydamage = GameManager.instance.enemydamage;
        moveSpeed = GameManager.instance.enemyspeed;
    }

    void FixedUpdate()
    {

        if (playerInCollider && distanceToPlayer > attackrange)
        {
            ChasePlayer();
        }
        else if (distanceToPlayer < attackrange && playerInCollider)
        {
            StartCoroutine(Attack());
        }
        else if(!chasing)
        {
            Move();
        }
    }
    private void Update()
    {
        DistanceToPlayer();
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
        enemyAnim.SetBool("Attack", isAttacking);
        enemyAnim.SetBool("isWalking", Mathf.Abs(transform.position.x) > 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = true;
            chasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = false;
            chasing = false;
        }
    }
    private void Move()
    {
        Debug.Log("Im moving");
        Vector2 targetPosition = isFacingRight ? rightLimit.position : leftLimit.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

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
            enemyRb.velocity = new Vector2(direction * moveSpeed, enemyRb.velocity.y);
        }
    }
    private void DistanceToPlayer()
    {
        distanceToPlayer = player.transform.position.x - transform.position.x;

    }
    private IEnumerator Attack()
    {
        Debug.Log("Im attacking");

        canAttack = false;
        isAttacking = true;
        if (hitbox.isPlayerinCollision)
        {
            playerHealth.TakeDamage(enemydamage);
        }
        yield return new WaitForSeconds(enemyAnim.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false;
        yield return new WaitForSeconds(attackCD);
        isAttacking = true;
    }

}
