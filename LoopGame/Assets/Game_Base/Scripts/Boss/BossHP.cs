using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float currentHealth;
    public float maxHealth = 50f;
    private newEnemy enemyhp;
    public GameObject coinPrefab;
    public Transform bosstransform;
    private void Start()
    {
        BossHealScaling();
        currentHealth = maxHealth;
        HealthBarUpdater(currentHealth, maxHealth); 
    }

    public void HealthBarUpdater(float current, float max)
    {
        slider.value = current / max;
    }
    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        HealthBarUpdater(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            DropCoin();
            GameManager.instance.AddCoins(20);
            Destroy(gameObject);
        }
    }
    public void BossHealScaling()
    {
        maxHealth = maxHealth + (GameManager.instance.score / 10);
    }
    private void DropCoin()
    {
        Vector3 spawnPosition = bosstransform.position + new Vector3(0, 1f, 0);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}

