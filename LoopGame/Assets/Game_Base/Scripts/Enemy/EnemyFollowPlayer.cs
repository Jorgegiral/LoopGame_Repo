using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public Transform player;
    public float shootingRange = 7f;
    public GameObject bullet;
    public GameObject bulletParent;
    private float nextAttack;
    [SerializeField] Animator rangedanim;
    private bool isFacingRight = true;
    [SerializeField]  float attackCD = 3.0f;
    void Start()
    {
        GameManager.instance.enemycount += 1;
        rangedanim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        FacePlayer();
        float distanceFromPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceFromPlayer <= shootingRange && nextAttack  <Time.time)
        {
            rangedanim.SetTrigger("Attack_Ranged");
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextAttack = Time.time + attackCD;
        }
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

}