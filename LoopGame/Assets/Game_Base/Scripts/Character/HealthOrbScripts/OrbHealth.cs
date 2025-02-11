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
    [Header("Knockback Settings")]
    public float knockbackForce = 5f; 
    public float knockbackDuration = 0.2f;
    private Rigidbody2D rb;
    private bool isKnockedBack = false;
    private SpriteRenderer spriteRenderer;
    #endregion

    #region UnityFunctions
    private void Awake()
    {
        startingHealth = PlayerManager.instance.playerMaxHealth;
        currentHealth = PlayerManager.instance.currentHealth;
        rb = GetComponent<Rigidbody2D>(); 
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    #endregion

    #region Functions
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        PlayerManager.instance.currentHealth = currentHealth;
        if (!isKnockedBack)
        {
            StartCoroutine(Knockback());
        }
        if (currentHealth <= 0)
        {
            
        }
    }

    public void HealDamage(float damage)
    {
                currentHealth += damage;
        PlayerManager.instance.currentHealth = currentHealth;
        PlayerManager.instance.playerMaxHealth = startingHealth;
        if (currentHealth > startingHealth)
        {
            currentHealth = startingHealth;
            PlayerManager.instance.currentHealth = currentHealth;

        }

    }
    private IEnumerator Knockback()
    {
        isKnockedBack = true;
        float direction = spriteRenderer.flipX ? 1f : -1f; 

    
        Vector2 knockbackDirection = new Vector2(direction, 0f).normalized;

       
        rb.velocity = Vector2.zero;
        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        yield return new WaitForSeconds(knockbackDuration);
        isKnockedBack = false;
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
                PlayerManager.instance.AddPotions(-1);
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

