using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float currentHealth;
    public float maxHealth = 50f;
    public GameObject coinPrefab;
    public Transform bosstransform;
    public TMP_Text bossHpText;
    [SerializeField] GameObject arenalimit;

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
    public void TextUpdater()
    {
        bossHpText.text = currentHealth +" / "+maxHealth;
    }
    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        HealthBarUpdater(currentHealth, maxHealth);
        TextUpdater();
        if (currentHealth <= 0)
        {

            DropCoin();
            arenalimit.SetActive(false);
            GameManager.instance.AddCoins(25);
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

