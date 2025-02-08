using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class OrbHealth : MonoBehaviour
{
    #region Variables
    public static OrbHealth instance;
    public float startingHealth;
    public float currentHealth;
  
    private bool PotionReady = true;

    #endregion

    #region UnityFunctions
    private void Awake()
    {
        startingHealth = GameManager.instance.playerMaxHealth;
        currentHealth = GameManager.instance.currentHealth;
    }
    #endregion

    #region Functions
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(0.2f);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);
        currentHealth -= damage;
        GameManager.instance.currentHealth = currentHealth;

        if (currentHealth < 0)
        {
            // Lose
        }
    }
    public void HealDamage(float damage)
    {
        
        currentHealth = Mathf.Clamp(currentHealth + damage, 0, startingHealth);
        currentHealth += damage;
        GameManager.instance.currentHealth = currentHealth;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
            GameManager.instance.currentHealth = currentHealth;

        }

    }

    #endregion

    #region Input Events

    public void HealingPotion()
    {

            if (PotionReady) 
            {
                if (GameManager.instance.potions <= 0) 
                {
                    Debug.Log("No potions left");
                }
                else
                {
                    
                    HealDamage(0.5f);
                    GameManager.instance.potions -= 1; 
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

