using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;



public class SceneSystem : MonoBehaviour
{
    #region Variables
    private int SceneRandomizer;
    private int numRandom;
    #endregion
    #region Functions
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void SceneVillage()
    {
        SceneManager.LoadScene(1);
    }
    public void Shop()
    {
        SceneManager.LoadScene(6);
    }
    public void TestLevel()
    {
        SceneManager.LoadScene(6);
    }
    public void BossLevel()
    {
        SceneManager.LoadScene(4);
    }
    public void Descansito()
    {
        SceneManager.LoadScene(2);
    }
    public void Aldeadefinitiva()
    {
        SceneManager.LoadScene(7);
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }

    #endregion
}
