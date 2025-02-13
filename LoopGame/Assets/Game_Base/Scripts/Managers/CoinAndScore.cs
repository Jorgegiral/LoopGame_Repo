using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinAndScore : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text coinsText;
    public int score = 0;
    public int coins = 0;
    public static CoinAndScore instance;

    private void Update()
    {
        

        UpdateScoreCoinsUI();
    }
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
    void Start()
    {
        UpdateScoreCoinsUI();
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

}
