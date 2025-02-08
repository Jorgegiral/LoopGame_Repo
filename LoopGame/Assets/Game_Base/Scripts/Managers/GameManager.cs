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
    public int score = 0;
    public int coins = 0;
    public float enemydamage = 3f;
    public float enemyhealth = 10f;
    public float enemyspeed = 2f;
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
