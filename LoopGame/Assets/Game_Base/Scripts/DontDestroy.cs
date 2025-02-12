using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    int sceneIndex;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            Destroy(gameObject);
        }

            DontDestroyOnLoad(gameObject);

    }


}
