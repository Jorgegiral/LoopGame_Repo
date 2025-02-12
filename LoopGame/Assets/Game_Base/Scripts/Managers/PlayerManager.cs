using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    private OrbHealth playerupdater;
    public float currentHealth;
    public float playerMaxHealth = 10f;
    public int potions = 3;
    public  TMP_Text potionText;
    public float playerDamage = 5f;
    public float attackColdown = 2f;
    public float jumpForcePlayer = 7f;
    public float speed = 4f;
    public float dashingpower = 8f;
    public float dashingrange = 0.2f;
    public float dashCD = 3f;
    public bool statsChanged;
    void Awake()
    {
        gameObject.SetActive(true);
        statsChanged = false;
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
    private void Start()
    {

    }
    public void UpdatePotionUI()
    {
        if (potionText != null)
        {
            
            potionText.text = potions.ToString();
        }
    }
    public void AddPotions(int points)
    {
        potions += points;

        UpdatePotionUI();
    }
    public void NewGame()
    {
    playerMaxHealth = 10f;
    currentHealth = playerMaxHealth;
    potions = 3;
    playerDamage = 5f;
    jumpForcePlayer = 5f;
    speed = 4f;
    dashingpower = 8f;
    dashingrange = 0.2f;
        dashCD = 3f;
    }
   

}
