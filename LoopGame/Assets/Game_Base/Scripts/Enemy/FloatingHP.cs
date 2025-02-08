using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class FloatingHP : MonoBehaviour
{
    [SerializeField] Slider slider;
    private newEnemy enemyHealth;
    float maxHealth;   
    float playerDamage;

    private void Start()
    {
        playerDamage = PlayerManager.instance.playerDamage;
        maxHealth = enemyHealth.enemymaxhealth;
        HealthBarUpdater(enemyHealth.enemycurrenthealth, maxHealth);

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
        
        enemyHealth.enemycurrenthealth -= playerDamage;
        HealthBarUpdater(enemyHealth.enemycurrenthealth, maxHealth);

        if (enemyHealth.enemycurrenthealth < 0)
        {
            Destroy(gameObject);
        }
    }
}
