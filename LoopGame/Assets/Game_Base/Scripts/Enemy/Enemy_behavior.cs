using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy_behavior : MonoBehaviour
{
    #region Variables
    //public
    public float attackDistance;
    public float moveSpeed;
    public float cdAttack;
    public Transform leftLimit;
    public Transform rightLimit;
    public Transform target;
    public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    //private
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool cooling;
    private float intTimer;
    private bool isFacingRight;

    
    #endregion
    #region UnityFunctions
    private void Awake()
    {
        SelectTarget();
        intTimer = cdAttack;
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (!attackMode)
        {
            //Para Patrol
            Move();
        }
        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }
    }

    #endregion
    #region Functions
    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
          //SI QUIERO QUE UN ENEMIGO NO HAGA PATRULLA ->  Move();
            StopAttack();
        }
        else if (attackDistance > distance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            Cooldown();
            anim.SetBool("Attack", false);

        }
    }
    private void Move()
    {
        anim.SetBool("canWalk",true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position,targetPosition,moveSpeed * Time.deltaTime);
        }
    }
    private void Attack()
    {

        cdAttack = intTimer;
        attackMode = true;
        anim.SetBool("canWalk",false);
        anim.SetBool("Attack",true);               
    }
    private void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack",false );
    }
    void Cooldown()
    {
        cdAttack -= Time.deltaTime;
        if (cdAttack < 0 && cooling && attackMode)
        {
            cooling = false;
            cdAttack = intTimer;
        }
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    private bool InsideofLimits()
    {
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }
    public void SelectTarget()
    {
        float distancetoLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distancetoRight = Vector2.Distance(transform.position, rightLimit.position);
        if (distancetoLeft > distancetoRight)
        {
            target = leftLimit;
        }
        else
        {
            target = rightLimit;
        }
        Flip();
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;

        if (transform.position.x < target.position.x) // Cambia el signo "<" por ">" si gira al revés
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;

    }
#endregion
}

