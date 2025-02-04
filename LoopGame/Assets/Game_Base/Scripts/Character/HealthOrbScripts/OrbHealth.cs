using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHealth : MonoBehaviour
{
    #region Variables
    public static OrbHealth instance;
    public float startingHealth = 3;
    public float currentHealth; //CAMBIAR IMPORTANTE UNA VEZ LO VEA JORGE

    #endregion

    #region UnityFunctions
    private void Awake()
    {
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

    }
    
    #endregion


}
