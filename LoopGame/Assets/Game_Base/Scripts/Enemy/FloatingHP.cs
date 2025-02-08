using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    float maxHealth;
    float currentHealth;
    float playerDamage;

    private void Start()
    {
        playerDamage = PlayerManager.instance.playerDamage;
        maxHealth = GameManager.instance.enemyhealth;
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
    public void TakeDamage()
    {
        
        currentHealth -= playerDamage;
        HealthBarUpdater(currentHealth, maxHealth);

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
