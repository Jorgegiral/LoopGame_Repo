using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManagement : MonoBehaviour
{
    [SerializeField] GameObject[] spots;
    [SerializeField] int spotRandomizer;
    [SerializeField] int spotSelector;
    

    void Start()
    {
        spotRandomizer = Random.Range(1, 101);
        spotSelector = Random.Range(1, 5);
        if (spotRandomizer <= 35)
        {
            ActivateRandomSpots(1);

        }
        else if (spotRandomizer <= 60)
        {
            ActivateRandomSpots(2);


        }
        else if (spotRandomizer <= 90)
        {
            ActivateRandomSpots(3);

        }
        else
        {
            ActivateRandomSpots(4);


        }
    }
    void ActivateRandomSpots(int amount)
    {
        if (spots.Length < amount) amount = spots.Length; 

        List<int> availableIndexes = new List<int>();
        for (int i = 0; i < spots.Length; i++)
        {
            availableIndexes.Add(i);
        }

        for (int i = 0; i < amount; i++)
        {
            int randomIndex = Random.Range(0, availableIndexes.Count);
            spots[availableIndexes[randomIndex]].SetActive(true);
            availableIndexes.RemoveAt(randomIndex);
        }
    }
    public void GoToVillage()
    {
        SceneManager.LoadScene(1);

    }

}
