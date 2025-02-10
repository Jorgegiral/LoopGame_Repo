using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float  currentHealth;
    public float  maxHealth = 10f ;
    public GameObject coinPrefab;
    public Transform enemytransform;
    private void Start()
    {

        EnemyHealScaling();
        currentHealth = maxHealth;
        HealthBarUpdater(currentHealth, maxHealth);

    }
    void Update()
    {
        
    }
    public void HealthBarUpdater(float current, float max)
    {
        slider.value = current/max;
    }
    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;
        HealthBarUpdater(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            GameManager.instance.enemycount -= 1;
            DropCoin(); 
            Destroy(gameObject);
        }
    }
    public void EnemyHealScaling()
    {
        maxHealth = maxHealth + (GameManager.instance.score / 9);
    }
    private void DropCoin()
    {
        Vector3 spawnPosition = enemytransform.position + new Vector3(0, 1f, 0);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);   
    }
}
