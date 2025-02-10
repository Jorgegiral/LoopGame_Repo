using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bossRb;
    [SerializeField] private GameObject player;
    [SerializeField] private OrbHealth playerhealth;
    [SerializeField] Animator bossAnim;
    private bool isFacingRight = true;
    [SerializeField] BossHP bossHp;
    private bool playerInCollider = false;

    [Header("Ability Parameters")]

    [SerializeField] GameObject spikeAbility;
    [SerializeField] GameObject meteorAbility;
    [SerializeField] GameObject fireballAbility;
    [SerializeField] GameObject fireballParent;
    [SerializeField] GameObject meteorParent;
    [SerializeField] GameObject spikeParent;
    public float shootingRange = 20f;
    private float nextFireball;
    private float nextMeteor;
    private float nextSpike;





    [Header("Stats Parameters")]
    public float bossdamage = 2f;
    public float fireballAbilityCooldown = 5f;
    public float meteorAbilityCooldown = 10f;
    public float spikeAbilityCooldown = 15f;
    private bool isAttacking = false;
    public float timeBetweenAttacks = 4f;

    private void Awake()
    {
        ScaleSystem();
    }
    void Start()
    {
        bossAnim = GetComponent<Animator>();
        bossRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<OrbHealth>();
    }

    void Update()
    {
        FacePlayer();
        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireball < Time.time)
        {
            bossAnim.SetTrigger("Attack_Ranged");
            Instantiate(fireballAbility, fireballParent.transform.position, Quaternion.identity);
            nextFireball = Time.time + fireballAbilityCooldown;
        }
 /*       if (distanceFromPlayer <= shootingRange && nextMeteor < Time.time)
        {
            bossAnim.SetTrigger("Attack_Ranged");
            Instantiate(meteorAbility, meteorParent.transform.position, Quaternion.identity);
            nextMeteor = Time.time + meteorAbilityCooldown;
        }
        if (distanceFromPlayer <= shootingRange && nextSpike < Time.time)
        {
            bossAnim.SetTrigger("Attack_Ranged");
            Instantiate(spikeAbility, spikeParent.transform.position, Quaternion.identity);
            nextSpike = Time.time + spikeAbilityCooldown;
        }*/
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInCollider = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerhealth.TakeDamage(bossdamage / 2f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    #region ScalingStats
    void ScaleSystem()
    {
        TimeBetweenAttacksScaling();
        EnemyDamageScaling();
        EnemyFirstAbilityCDScaling();
        EnemySecondAbilityCDScaling();
        EnemyThirdAbilityCDScaling();
    }

    public void EnemyDamageScaling()
    {
        bossdamage = bossdamage + (GameManager.instance.score / 10);
    }
    public void EnemyFirstAbilityCDScaling()
    {
        fireballAbilityCooldown = fireballAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void EnemySecondAbilityCDScaling()
    {
        meteorAbilityCooldown = meteorAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void EnemyThirdAbilityCDScaling()
    {
        spikeAbilityCooldown = spikeAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void TimeBetweenAttacksScaling()
    {
        timeBetweenAttacks = timeBetweenAttacks- (GameManager.instance.score / 50);
    }
    #endregion
}

