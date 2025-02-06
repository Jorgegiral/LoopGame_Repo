using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OrbHealth : MonoBehaviour
{
    #region Variables
    public static OrbHealth instance;
    public float startingHealth = 3;
    public float maxHealth;
    public float currentHealth;
    public  int healingUses;
    private bool PotionReady = true;

    #endregion

    #region UnityFunctions
    private void Awake()
    {
        healingUses = 3;
        maxHealth = startingHealth;
        currentHealth = startingHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(0.05f);
        }
    }
    #endregion

    #region Functions
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        currentHealth -= damage;


        if (currentHealth < 0)
        {
            // Lose
        }
    }
    public void HealDamage(float damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth + damage, 0, startingHealth);
        currentHealth += damage;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    #endregion

    #region Input Events

    public void HealingPotion()
    {

            if (PotionReady) 
            {
                if (healingUses <= 0) 
                {
                    Debug.Log("No potions left");
                }
                else
                {
                    
                    HealDamage(0.5f);
                    healingUses -= 1; 
                    PotionReady = false; 

                    
                    StartCoroutine(PotionCooldown());
                }
            }
            else
            {
                Debug.Log("Potion is not ready");
            }
        
    }
    private IEnumerator PotionCooldown()
    {
        yield return new WaitForSeconds(3f);
        PotionReady = true; 
    }
}
    #endregion

