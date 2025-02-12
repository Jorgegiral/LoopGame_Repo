using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBoss : MonoBehaviour
{
    GameObject target;
    public float speed =4;
    Rigidbody2D bulletRB;
    public OrbHealth playerHealth;
    float bulletdmg = 5;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        playerHealth = target.gameObject.GetComponent<OrbHealth>();
        Vector2 movedir = (target.transform.position - transform.position).normalized * speed;

        //bulletRB.velocity = new Vector2(movedir.x, movedir.y); codigo Adrian

        //codigo Jorge:
        bulletRB.velocity = movedir;
        float angle = Mathf.Atan2(movedir.y, movedir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
        //
        Destroy(this.gameObject, 6f);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletdmg);
            Destroy(gameObject);
        }


    }

}
