using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.CullingGroup;

public class DontDestroy : MonoBehaviour
{
    [SerializeField]  GameObject persistentObject;

    void Awake()
    {
        gameObject.SetActive(true);
        if (persistentObject != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else if (persistentObject == null)
        {
            Destroy(gameObject);
        }
    }

}
