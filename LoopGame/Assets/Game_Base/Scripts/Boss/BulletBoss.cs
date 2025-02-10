using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    OrbHealth playerHealth;
    BossBehaviour boss;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        playerHealth = target.gameObject.GetComponent<OrbHealth>();
        Destroy(this.gameObject, 2.5f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(boss.bossdamage);
            Destroy(gameObject);
        }
    }


}
