using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsSceneChanger : MonoBehaviour
{
    int sceneIndex = SceneManager.GetActiveScene().buildIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && sceneIndex == 2)
        {
            GameManager.instance.AddScore(1);
            SceneVillage();
        }
        if (collision.CompareTag("Player") && sceneIndex == 3)
        {
            GameManager.instance.AddScore(5);
            SceneVillage();
        }
        if (collision.CompareTag("Player") && sceneIndex == 4)
        {
            GameManager.instance.AddScore(15);
            SceneVillage();
        }
    }
    public void SceneVillage()
    {
        SceneManager.LoadScene(1);
    }
}
