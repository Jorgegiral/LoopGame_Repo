using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseItem : MonoBehaviour
{
    [SerializeField] GameObject[] itemsInSpot;
    int numSelector;
    int numActive;
    void Start()
    {
        numActive = Random.Range(0, 2);
        numSelector = Random.Range(0, itemsInSpot.Length);
        itemsInSpot[numSelector].SetActive(true);
    }
}
