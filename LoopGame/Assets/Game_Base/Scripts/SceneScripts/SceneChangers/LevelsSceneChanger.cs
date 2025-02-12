using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsSceneChanger : MonoBehaviour
{
    int sceneIndex;

    private void Start()
    {
         sceneIndex = SceneManager.GetActiveScene().buildIndex;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && GameManager.instance.levelCompleted )
        {
            if (gameObject.CompareTag("Right"))
            {
                GameManager.instance.spawnRight = true;
            }
            else if (gameObject.CompareTag("Left"))
            {
                GameManager.instance.spawnRight = false;
            }
            if (sceneIndex == 2)
            {
                GameManager.instance.AddScore(5);
            }
            else if (sceneIndex == 3)
            {
                GameManager.instance.AddScore(10);
            }
            else if (sceneIndex == 4)
            {
                GameManager.instance.AddScore(20);
            }
            GameManager.instance.levelCompleted = false;
            SceneVillage();
        }
    }
    public void SceneVillage()
    {
        SceneManager.LoadScene(1);
    }
}
