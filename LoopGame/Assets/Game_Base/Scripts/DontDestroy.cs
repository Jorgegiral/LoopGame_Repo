using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private static GameObject[] persistentObjects = new GameObject[3];
    public int objectIndex;
    int sceneIndex;

    void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
        {
            if (persistentObjects[objectIndex] != null)
            {
                Destroy(persistentObjects[objectIndex]);
                persistentObjects[objectIndex] = null; 
            }

        }

        if (persistentObjects[objectIndex] == null)
        {
            persistentObjects[objectIndex] = gameObject;
            DontDestroyOnLoad(gameObject);

        }
        else if(persistentObjects[objectIndex] != gameObject)
        {
            Destroy(gameObject);
        }
    }


}
