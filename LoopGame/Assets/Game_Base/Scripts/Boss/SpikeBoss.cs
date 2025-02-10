using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBoss : MonoBehaviour
{
    GameObject target;
    Rigidbody2D bulletRB;
    public OrbHealth playerHealth;
    float bulletdmg = 3;

    void Start()
    {
        
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player");
        playerHealth = target.gameObject.GetComponent<OrbHealth>();
        Destroy(this.gameObject, 2f);
    }

    private void Update()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.TakeDamage(bulletdmg);
            Destroy(gameObject);
        }
    }


}
