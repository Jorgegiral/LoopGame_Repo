using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    public TMP_Text scoreText;
    public TMP_Text coinsText;
    public int score = 0;
    public int coins = 0;
    public bool spawnRight;
    public bool levelCompleted = false;
    public int enemycount;
    public bool bosskilled;
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

            scoreText.text = "SCORE: " + score;
        }
        if (coinsText != null)
        {

            coinsText.text = "GOLD: " + coins;
        }
    }
    public void NewGame()
    {
        score = 0;
        coins = 0;
    }
    public void AddCoins(int points)
    {
        coins += points;

        UpdateScoreCoinsUI();
    }
    public void AddScore(int points)
    {
        score += points;

        UpdateScoreCoinsUI();
    }


    #endregion
}
