using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    float maxHealth = 5f;
    float currentHealth;

    private void Start()
    {
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
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        currentHealth -= damage;
        HealthBarUpdater(currentHealth, maxHealth);

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
