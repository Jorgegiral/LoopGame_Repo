using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public float currentHealth;
    public float playerMaxHealth = 10f;
    public int potions = 3;
    public float playerDamage = 5f;
    public float jumpForce = 7f;
    public float speed = 4f;
    public float dashingpower = 8f;
    public float dashingrange = 0.2f;


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
    public void NewGame()
    {
    playerMaxHealth = 10f;
    potions = 3;
    playerDamage = 5f;
    jumpForce = 5f;
    speed = 4f;
    dashingpower = 8f;
    dashingrange = 0.2f;
    }

}
