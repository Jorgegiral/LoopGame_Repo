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
    [SerializeField] private OrbHealth playerhealth;
    [SerializeField] Animator enemyAnim;
    private float hitForce;
    private bool isFacingRight = true;
    private bool playerInCollider = false;
    [SerializeField] FloatingHP enemyHp;
    private float distanceToPlayer;
    private Vector3 initScale;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private bool movingLeft;

    [Header("Stats Parameters")]
    public float enemyspeed = 2f;
    private bool isAttacking = false;
    [SerializeField] public float attackCD = 3.0f;

    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        ScaleSystem();
        GameManager.instance.enemycount += 2;
        initScale = gameObject.transform.localScale;
        enemyAnim = GetComponent<Animator>();
        enemyRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<OrbHealth>();

    }

    void FixedUpdate()
    {
        cooldownTimer += Time.deltaTime;
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
        if (!isAttacking ) 
        {       
                if (movingLeft)
                {
                    if (gameObject.transform.position.x >= leftLimit.position.x)
                        MoveInDirection(-1);
                    else
                        DirectionChange();
                }
                else
                {
                    if (gameObject.transform.position.x <= rightLimit.position.x)
                        MoveInDirection(1);
                    else
                        DirectionChange();
                }
            
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

        if ((playerIsRight && !isFacingRight) || (!playerIsRight && isFacingRight))
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


    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(enemyAnim.GetCurrentAnimatorStateInfo(0).length);
        isAttacking = false; 
    }




    private void DirectionChange()
    {
        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        gameObject.transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction,
            initScale.y, initScale.z);

        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + Time.deltaTime * _direction * enemyspeed,
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );
    }
    void ScaleSystem()
    {
        EnemyAttackCDScaling();
        EnemySpeedScaling();
    }

    public void EnemyAttackCDScaling()
    {
        attackCD = attackCD - (GameManager.instance.score/200);
    }
    public void EnemySpeedScaling()
    {
        enemyspeed = enemyspeed + (GameManager.instance.score / 100);
    }
}




