using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsSceneChanger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneVillage();
        }
    }
    public void SceneVillage()
    {
        SceneManager.LoadScene(1);
    }
}
