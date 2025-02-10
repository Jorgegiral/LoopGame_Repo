using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    public Transform player;
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    public float attackCD = 3f;
    private float nextAttack;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, player.transform.position);
        if (distanceFromPlayer <= shootingRange && nextAttack  <Time.time)
        {
            Instantiate(bullet,bulletParent.transform.position,Quaternion.identity);
            nextAttack = Time.time + attackCD;
        }
    }

}