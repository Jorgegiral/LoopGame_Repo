using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menuPause;

    private void Start()
    {
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.instance.currentGameState == GameManager.GameState.GameRunning)
            {
                PauseMenu();
            }
            else if (GameManager.instance.currentGameState == GameManager.GameState.GamePaused)
            {
                ResumeGame();
            }
        }
    }
    public void ResumeGame()
    {
        GameManager.instance.currentGameState = GameManager.GameState.GameRunning;
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
    public void PauseMenu()
    {
        GameManager.instance.currentGameState = GameManager.GameState.GamePaused;
        Time.timeScale = 0f;
        menuPause.SetActive(true);
    }
}
