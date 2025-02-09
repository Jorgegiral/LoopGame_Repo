using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private GameObject player;
    [SerializeField] private OrbHealth playerhealth;
    [SerializeField] Animator bossAnim;
    private bool isFacingRight = true;
    [SerializeField] BossHP bossHp;
    private bool playerInCollider = false;

    [Header("Stats Parameters")]
    public float bossdamage = 2f;
    public float firstAbilityCooldown = 3f;
    public float secondAbilityCooldown = 7f;
    public float thirdAbilityCooldown = 10f;
    public float timeBetweenAbilities = 3f;
    private bool isAttacking = false;
   


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FacePlayer();
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
    #region ScalingStats
    void ScaleSystem()
    {
        EnemyDamageScaling();
        EnemyFirstAbilityCDScaling();
        EnemySecondAbilityCDScaling();
        EnemyThirdAbilityCDScaling();
        timeBetweenAbilitiesCDScaling();
    }

    public void EnemyDamageScaling()
    {
        bossdamage = bossdamage + (GameManager.instance.score / 10);
    }
    public void EnemyFirstAbilityCDScaling()
    {
        firstAbilityCooldown = firstAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void EnemySecondAbilityCDScaling()
    {
        secondAbilityCooldown = firstAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void EnemyThirdAbilityCDScaling()
    {
        thirdAbilityCooldown = firstAbilityCooldown - (GameManager.instance.score / 50);
    }
    public void timeBetweenAbilitiesCDScaling()
    {
        thirdAbilityCooldown = firstAbilityCooldown - (GameManager.instance.score / 50);
    }
    #endregion
}

