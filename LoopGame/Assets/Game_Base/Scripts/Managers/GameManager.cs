using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text coinsText;
    public float currentHealth;
    public float playerMaxHealth = 3;
    public int potions = 3;
    public int score = 0;
    public int coins = 0;
    public enum GameState
    {
        GameRunning,
        GamePaused,
        GameOver
    }
    #endregion
    #region UnityFunctions
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
    void Start()
    {
        UpdateScoreCoinsUI();
    }
    #endregion
    #region Functions
    public void UpdateScoreCoinsUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        if (coinsText != null)
        {
            scoreText.text = "Coins: " + score;
        }
    }
    void NewGame()
    {
        potions = 3;
        score = 0;
        coins = 0;
    }
    public void AddCoins(int points)
    {
        score += points;

        UpdateScoreCoinsUI();
    }
    public void AddScore(int points)
    {
        score += points;
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
        UpdateScoreCoinsUI();
    }
    #endregion
}
