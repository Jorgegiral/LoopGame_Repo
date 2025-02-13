using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

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
    public float shootingRange = 12f;
    private float nextFireball;
    private float nextMeteor;
    private float nextSpike;
    [SerializeField] private Slider cooldownAttackSlider;
    private float cooldownTimer = 0f;




    [Header("Stats Parameters")]
    public float bossdamage = 2f;
    public float fireballAbilityCooldown = 5f;
    public float meteorAbilityCooldown = 8f;
    public float spikeAbilityCooldown = 12f;
    private bool isAttacking = false;
    public float timeBetweenAttacks = 4f;
    private bool attackReady = true;
    private float globalCooldown;
    private void Awake()
    {
        ScaleSystem();
    }
    void Start()
    {
        GameManager.instance.enemycount += 2;
        bossAnim = GetComponent<Animator>();
        bossRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<OrbHealth>();
        cooldownAttackSlider = GameObject.Find("BossAttackCD").GetComponent<Slider>();

    }

    void Update()
    {
        UpdateAttackCooldownUI();
        cooldownTimer += Time.deltaTime;
        globalCooldown += Time.deltaTime;
        FacePlayer();
        float distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (attackReady)
        {
            if (distanceFromPlayer <= shootingRange && nextFireball < Time.time)
            {

                bossAnim.SetTrigger("Attack_Ranged");
                Instantiate(fireballAbility, fireballParent.transform.position, Quaternion.identity);
                nextFireball = Time.time + fireballAbilityCooldown;
                attackReady = false;
                cooldownTimer = 0;
            }
            else if (distanceFromPlayer <= shootingRange && nextMeteor < Time.time)
            {
                bossAnim.SetTrigger("Boss_Spell");
                Instantiate(meteorAbility, meteorParent.transform.position, Quaternion.identity);
                nextMeteor = Time.time + meteorAbilityCooldown;
                attackReady = false;
            }
            else if (playerInCollider && nextSpike < Time.time)
            {
                Vector3 spikelocation = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
                bossAnim.SetTrigger("Boss_Spell2");
                Instantiate(spikeAbility, spikelocation, Quaternion.identity);
                nextSpike = Time.time + spikeAbilityCooldown;
                attackReady = false;
            }
        }
        else
        {
            TimeBetweenAttacks();
        }
    }
    private void UpdateAttackCooldownUI()
    {
        cooldownAttackSlider.value = cooldownTimer / fireballAbilityCooldown;

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
    private void TimeBetweenAttacks()
    {
        if (globalCooldown >= timeBetweenAttacks) 
        {
            attackReady = true;
            globalCooldown = 0f;
        }
    }
    #region ScalingStats
    void ScaleSystem()
    {
        TimeBetweenAttacksScaling();
        EnemyFirstAbilityCDScaling();
        EnemySecondAbilityCDScaling();
        EnemyThirdAbilityCDScaling();
    }

    public void EnemyFirstAbilityCDScaling()
    {
        fireballAbilityCooldown = fireballAbilityCooldown - (CoinAndScore.instance.score / 10);
    }
    public void EnemySecondAbilityCDScaling()
    {
        meteorAbilityCooldown = meteorAbilityCooldown - (CoinAndScore.instance.score / 10);
    }
    public void EnemyThirdAbilityCDScaling()
    {
        spikeAbilityCooldown = spikeAbilityCooldown - (CoinAndScore.instance.score / 10);
    }
    public void TimeBetweenAttacksScaling()
    {
        timeBetweenAttacks = timeBetweenAttacks- (CoinAndScore.instance.score / 25);
    }
    #endregion
}

