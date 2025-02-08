using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public float currentHealth;
    public float playerMaxHealth = 10;
    public int potions = 3;
    public float playerDamage = 5;
    void Awake()
    {
        gameObject.SetActive(true);

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        currentHealth = playerMaxHealth;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
