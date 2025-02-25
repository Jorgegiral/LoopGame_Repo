using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyScene : MonoBehaviour
{

    private static Dictionary<string, GameObject> persistentObjects = new Dictionary<string, GameObject>();

    [SerializeField] private string[] sceneToDestroy;

    void Awake()
    {
        string objName = gameObject.name;

        if (!persistentObjects.ContainsKey(objName))
        {
            persistentObjects[objName] = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        foreach (string scene in sceneToDestroy)
        {
            if (SceneManager.GetActiveScene().name == scene)
            {
                if (persistentObjects.ContainsKey(gameObject.name))
                {
                    Destroy(persistentObjects[gameObject.name]);
                    persistentObjects.Remove(gameObject.name);
                }
                break;
            }
        }
    }
}
