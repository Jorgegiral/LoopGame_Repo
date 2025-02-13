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
        bulletRB.velocity = movedir;
        float angle = Mathf.Atan2(movedir.y, movedir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);

        Destroy(this.gameObject, 4);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletDMG);
            Destroy(gameObject);
        }
    }
    void ScaleBulletDamage()
    {
        bulletDMG = bulletDMG + (CoinAndScore.instance.score / 10);
    }

}
