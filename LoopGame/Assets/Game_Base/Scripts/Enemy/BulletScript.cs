using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    OrbHealth playerHealth;
    public float bulletDMG = 2f;
    void Start()
    {
        ScaleBulletDamage();
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        playerHealth = target.gameObject.GetComponent<OrbHealth>();
        Vector2 movedir = (target.transform.position-transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(movedir.x, movedir.y);
        Destroy(this.gameObject, 4);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletDMG);
        }
    }
    void ScaleBulletDamage()
    {
        bulletDMG = bulletDMG + (GameManager.instance.score / 10);
    }

}
