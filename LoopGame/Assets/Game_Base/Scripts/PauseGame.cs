using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject menuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }
    void PauseMenu()
    {
        if (GameManager.instance.currentGameState == GameManager.GameState.GameRunning)
        {
            GameManager.instance.currentGameState = GameManager.GameState.GamePaused;
            Time.timeScale = 0;
            menuPause.SetActive(true);
        }
        else if (GameManager.instance.currentGameState == GameManager.GameState.GamePaused)
        {
            GameManager.instance.currentGameState = GameManager.GameState.GameRunning;
            Time.timeScale = 1;
            menuPause.SetActive(false);
        }
    }
}
