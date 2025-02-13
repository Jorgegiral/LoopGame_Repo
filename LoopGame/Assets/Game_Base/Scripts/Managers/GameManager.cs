using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    public bool spawnRight;
    public bool levelCompleted = false;
    public int enemycount;
    public bool bosskilled;
    public bool inShop;
    public bool itemBought;
    public int itemsRemain;
    public bool dailyVisit = true;
    public GameState currentGameState = GameState.GameRunning;
    public int slots = 6;

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
    public void NewGame()
    {
           levelCompleted = false;
         enemycount = 0;
        bosskilled = false;
        dailyVisit = true;

            }

    #endregion

}
