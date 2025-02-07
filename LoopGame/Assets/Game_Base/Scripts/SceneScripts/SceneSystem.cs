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
    public void SceneLevel()
    {
        numRandom = Random.Range(0, 6);
        if (numRandom == 2)
        {
            SceneRandomizer = Random.Range(2, 5);
        }
        else 
        { SceneRandomizer = Random.Range(2, 4); }

        SceneManager.LoadScene(SceneRandomizer);
    }
    public void Shop()
    {
        SceneManager.LoadScene(3);
    }
    #endregion
}
