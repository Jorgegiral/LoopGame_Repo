using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxTriggerPlayer : MonoBehaviour
{

    public bool isEnemyinCollision = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isEnemyinCollision = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy"))
        {
            isEnemyinCollision = true;
        }
    }
}
