using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {
        GameManager.instance.levelCompleted = false;
        GameManager.instance.enemycount = 0;
        GameManager.instance.bosskilled = false;
        GameManager.instance.dailyVisit = true;

    }
}
