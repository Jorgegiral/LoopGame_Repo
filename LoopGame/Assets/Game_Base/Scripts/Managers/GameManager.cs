using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    #region Variables
    public static GameManager instance;
    [SerializeField] TMP_Text scoretext;
    [SerializeField] TMP_Text coinstext;
    private OrbHealth playerHealth;
    private float currentHealth;
    private float playerMaxHealth;

    private int score = 0;
    private int coins = 0;
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

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        GetComponent<TMP_Text>();

    }
    #endregion
    #region Functions



    #endregion
}
