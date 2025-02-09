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
        if ( PlayerManager.instance.potions == 3)
        {
            numRandom = Random.Range(0, 7);
            if (numRandom == 2)
            {
                SceneRandomizer = Random.Range(3, 5);
            }
            else { SceneRandomizer = 3; }
        }
        else
        {
            numRandom = Random.Range(0, 6);
            if (numRandom == 2)
            {
                SceneRandomizer = Random.Range(2, 5);
            }

            { SceneRandomizer = Random.Range(2, 4); }
        }

        SceneManager.LoadScene(SceneRandomizer);
    }
}
