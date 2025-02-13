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
    public float attackColdown = 3f;
    public float jumpForcePlayer = 7f;
    public float speed = 4f;
    public float dashingpower = 8f;
    public float dashingrange = 0.2f;
    public float dashCD = 3f;
    public bool statsChanged;
    public bool itemadded;
    [SerializeField] TMP_Text attackText, healthText, attackCDText, speedText, jumpText, dashSpeedText, dashRangeText, dashCDText;

    [SerializeField] TMP_Text itemnamepreText, attackpreText, healthpreText, attackCDpreText, speedpreText, jumppreText, dashSpeedpreText, dashRangepreText, dashCDpreText;
    [SerializeField] GameObject selectedItemStats;
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
        UpdateEquipmentStats();
        TurnOffPreviewStats();

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


    public void UpdateEquipmentStats()
    {
        attackText.text = PlayerManager.instance.playerDamage.ToString();
        healthText.text = PlayerManager.instance.playerMaxHealth.ToString();
        attackCDText.text = PlayerManager.instance.attackColdown.ToString();
        speedText.text = PlayerManager.instance.speed.ToString();
        jumpText.text = PlayerManager.instance.jumpForcePlayer.ToString(); ;
        dashRangeText.text = PlayerManager.instance.dashingrange.ToString();
        dashSpeedText.text = PlayerManager.instance.dashingpower.ToString();
        dashCDText.text = PlayerManager.instance.dashCD.ToString();
    }
    public void PreviewEquipmentStats(string itemname,float attack, float health, float speed, float jump, float dashSpeed, float dashRange, float dashCD, float attackCD)
    {
        itemnamepreText.text = itemname;
        attackpreText.text = attack.ToString();
        healthpreText.text = health.ToString();
        attackCDpreText.text = attackCD.ToString();
        speedpreText.text = speed.ToString();
        jumppreText.text = jump.ToString(); 
        dashRangepreText.text = dashRange.ToString();
        dashSpeedpreText.text = dashSpeed.ToString();
        dashCDpreText.text = dashCD.ToString();
        selectedItemStats.SetActive(true);
    }
    public void TurnOffPreviewStats()
    {
        selectedItemStats.SetActive(false);
    }


}
