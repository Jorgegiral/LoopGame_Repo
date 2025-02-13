using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    GameObject target;
    public float speed= 3.5f;
    Rigidbody2D bulletRB;
    OrbHealth targetHealth;
    float bulletdmg = 2;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        targetHealth = target.gameObject.GetComponent<OrbHealth>();
        Destroy(this.gameObject, 2.5f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position, speed * Time.deltaTime);

        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetHealth.TakeDamage(bulletdmg);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }




}
