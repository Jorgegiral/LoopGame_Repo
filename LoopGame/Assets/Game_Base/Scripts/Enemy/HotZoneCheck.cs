using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Enemy_behavior enemyinstance;
    private bool inRange;
    private Animator anim;
    private void Awake()
    {
        enemyinstance = GetComponentInParent<Enemy_behavior>();
        anim = enemyinstance.GetComponent<Animator>();
    }
    private void Update()
    {
        if (inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        { 
            enemyinstance.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyinstance.triggerArea.SetActive(true);
            enemyinstance.inRange = false;
            enemyinstance.SelectTarget();
        }
    }
}
