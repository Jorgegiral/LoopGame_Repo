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
    #endregion
}
