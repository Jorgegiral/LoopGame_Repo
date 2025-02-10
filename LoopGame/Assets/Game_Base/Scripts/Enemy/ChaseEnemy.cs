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
        enemyAnim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
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
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, enemyspeed * Time.deltaTime);
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
        attackCD = attackCD - (GameManager.instance.score / 200);
    }
    public void EnemySpeedScaling()
    {
        enemyspeed = enemyspeed + (GameManager.instance.score / 100);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
