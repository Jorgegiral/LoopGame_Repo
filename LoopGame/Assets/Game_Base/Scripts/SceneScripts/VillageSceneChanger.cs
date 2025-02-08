using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneObject : MonoBehaviour
{
    #region Variables
    private int SceneRandomizer;
    private int numRandom;
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneLevel();
        }
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
}
