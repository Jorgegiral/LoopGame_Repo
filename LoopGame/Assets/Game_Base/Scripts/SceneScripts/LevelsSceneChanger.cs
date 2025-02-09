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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sceneIndex == 2)
            {
                GameManager.instance.AddScore(1);
            }
            else if (sceneIndex == 3)
            {
                GameManager.instance.AddScore(5);
            }
            else if (sceneIndex == 4)
            {
                GameManager.instance.AddScore(15);
            }
        }
        SceneVillage();
    }

    public void SceneVillage()
    {
        SceneManager.LoadScene(1);
    }
}
