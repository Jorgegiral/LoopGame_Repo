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
        startingHealth = PlayerManager.instance.playerMaxHealth;
        currentHealth = PlayerManager.instance.currentHealth;
    }
    #endregion

    #region Functions
    private void Update()
    {
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        PlayerManager.instance.currentHealth = currentHealth;

        if (currentHealth < 0)
        {
            // Lose
        }
    }
    public void HealDamage(float damage)
    {
                currentHealth += damage;
        PlayerManager.instance.currentHealth = currentHealth;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
            PlayerManager.instance.currentHealth = currentHealth;

        }

    }

    #endregion

    #region Input Events

    public void HealingPotion()
    {

            if (PotionReady) 
            {
                if (PlayerManager.instance.potions <= 0) 
                {
                    Debug.Log("No potions left");
                }
                else
                {
                    
                    HealDamage(5f);
                    PlayerManager.instance.potions -= 1; 
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

