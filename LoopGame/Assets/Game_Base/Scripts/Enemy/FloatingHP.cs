using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    public float  currentHealth;
    public float  maxHealth = 10;   

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
        
        currentHealth -= damage;
        HealthBarUpdater(currentHealth, maxHealth);

        if (currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
